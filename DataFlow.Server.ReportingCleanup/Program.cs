using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.Models;
using DataFlow.Common.DAL;
using DataFlow.Common.Enums;
using NLog;
using FluentEmail;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;
using SysConfig = System.Configuration;
using System.Net.Configuration;

namespace DataFlow.Server.ReportingCleanup
{
    class Program
    {
        public const string JANITOR_REPORT_LAST = "JANITOR_REPORT_LAST";
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            // Force TLS 1.2 as per Ed-Fi ODS-2403 -- https://tracker.ed-fi.org/browse/ODS-2403
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _log.Info("Reporting and Cleanup Janitor starting");

            EmailMessage emailMessage = new EmailMessage() { EmailDate = DateTime.Now.ToShortDateString() };

            var smtpSection = (SmtpSection)SysConfig.ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string fromEmail = smtpSection.From;

            using (var ctx = new DataFlowDbContext())
            {
                try
                {
                    // Get processed deleted files 
                    string daysToKeepFiles = SysConfig.ConfigurationManager.AppSettings["DaysToKeepFiles"];
                    int days;
                    if (daysToKeepFiles != null && daysToKeepFiles != "0" && int.TryParse(daysToKeepFiles, out days))
                    {
                        DateTime deleteFileDate = DateTime.Now.AddDays(-days);
                        List<File> deletedFiles = ctx.Files.Where(f => f.CreateDate <= deleteFileDate && f.Status != FileStatusEnum.DELETED).ToList();
                        emailMessage.DeleteDays = days;
                        emailMessage.DeletedFiles = deletedFiles;
                        foreach (var file in deletedFiles)
                        {
                            try
                            {
                                string fullFilePath = new System.Uri(file.Url).LocalPath;
                                System.IO.File.Delete(fullFilePath);
                                file.Status = FileStatusEnum.DELETED;
                            }
                            catch (Exception deleteEx)
                            {
                                _log.Error(deleteEx, "Error deleting file: {0}", file.FileName);
                            }
                        }
                        ctx.SaveChanges();
                    }

                    // Send email message
                    DateTime filterDate = DateTime.MinValue;
                    Configuration lastRan = ctx.Configurations.Where(c => c.Key == JANITOR_REPORT_LAST).FirstOrDefault();
                    if (lastRan == null) { 
                        lastRan = new Configuration() { Key = JANITOR_REPORT_LAST };
                        ctx.Configurations.Add(lastRan);
                    }
                    else
                        filterDate = DateTime.Parse(lastRan.Value);

                    lastRan.Value = DateTime.Now.ToString();

                    List<File> files = ctx.Files.Where(f => (f.CreateDate >= filterDate || f.UpdateDate >= filterDate) && f.Status != FileStatusEnum.DELETED).Include(f => f.Agent).ToList();

                    List<AspNetUser> users = ctx.AspNetUsers.ToList();
                    MailAddressCollection emails = new MailAddressCollection();
                    foreach (AspNetUser user in users)
                    {
                        emails.Add(new MailAddress(user.Email));
                    }

                    emailMessage.Files = files;

                    if (emailMessage.Files != null || emailMessage.DeletedFiles != null)
                    {
                        var email = Email
                            .From(fromEmail)
                            .To(emails)
                            .Subject(String.Format("Data Flow Status Update for {0}", emailMessage.EmailDate))
                            .UsingTemplateFromFile("./template.cshtml", emailMessage);

                        _log.Info("Sending email report to {0} for {1} of files", emails.ToString(), files.Count);
                        email.Send();
                    } else
                        _log.Info("No email report to send today (no processed or deleted files).");

                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    _log.Error(ex, "Unexpected error in ReportingCleanup service");
                }

            }

            _log.Info("Reporting and Cleanup Janitor ending");

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }

    }
}
