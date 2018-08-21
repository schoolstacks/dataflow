using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using FluentFTP;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System.Linq;
using System.Data;
using System.Net;
using DataFlow.Common;
using DataFlow.Common.DAL;
using DataFlow.Common.ExtensionMethods;
using DataFlow.Models;
using DataFlow.Common.Enums;
using DataFlow.Common.Helpers;
using NLog;

namespace DataFlow.Server.FileTransport
{
    public class Program
    {
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();

        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        private static readonly string _azureFileConnectionString = ConfigurationManager.ConnectionStrings["storageConnection"].ConnectionString;

        private static readonly string _fileMode = ConfigurationManager.AppSettings["FileMode"];
        private static string _shareName = ConfigurationManager.AppSettings["ShareName"]; // note:  not read only as we will ensure a trailing slash if in local file mode
        private static readonly string _encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
        private static readonly string _allowTestCertificates = ConfigurationManager.AppSettings["AllowTestCertificates"];

        public static void Main(string[] args)
        {
            // Force TLS 1.2 as per Ed-Fi ODS-2403 -- https://tracker.ed-fi.org/browse/ODS-2403
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _log.Info("File Transport Janitor starting");

            if (HaveConfigurationValues())
            {
                using (DataFlowDbContext ctx = new DataFlowDbContext())
                {
                    var agents = ctx.Agents.Where(agent => agent.Enabled == true && (agent.AgentTypeCode == AgentTypeCodeEnum.SFTP || agent.AgentTypeCode == AgentTypeCodeEnum.FTPS));

                    foreach (var agent in agents)
                    {
                        _log.Info("Processing agent name: {0}", agent.Name);

                        List<string> fileList = GetFileList(agent);

                        _log.Info("Items to process: {0}", fileList.Count);

                        foreach (string file in fileList)
                        {
                            _log.Info("Processing file: {0}", file);
                            // Check the file log to see if the file already exists, if not, upload to file storage
                            if (!DoesFileExistInLog(agent.Id, file))
                                TransferFileToStorage(agent, file);
                        }

                        agent.LastExecuted = DateTime.Now;
                    }

                    ctx.SaveChanges();
                }
            }

            _log.Info("File Transport Janitor exiting");

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }

        private static List<string> GetFileList(Agent agent)
        {
            switch (agent.AgentTypeCode)
            {
                case AgentTypeCodeEnum.SFTP:
                    return GetFileListFromSFTP(agent);
                    break;
                case AgentTypeCodeEnum.FTPS:
                    return GetFileListFromFTPS(agent);
                    break;
                default:
                    throw new NotImplementedException("Unexpected agent type provided to GetFileList");
            }
        }

        private static List<string> GetFileListFromFTPS(Agent ftpsagent)
        {
            List<string> list = new List<string>();

            try
            {
                _log.Info("Connecting to host: {0}", ftpsagent.Url);
                FtpClient client = new FtpClient(ftpsagent.Url, ftpsagent.Username, Encryption.Decrypt(ftpsagent.Password, _encryptionKey));
                client.EncryptionMode = FtpEncryptionMode.Implicit; // Only implicit FTPS on port 990
                client.ValidateCertificate += new FtpSslValidation(OnValidateFTPSCertificate);
                client.Connect();

                foreach (FtpListItem file in client.GetListing(ftpsagent.Directory))
                {
                    if (file.Type == FtpFileSystemObjectType.File && file.Name.IsLike(ftpsagent.FilePattern))
                        list.Add(file.FullName);
                }

                client.Disconnect();
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Unexpected exception in GetFileListFromFTPS()");
            }

            return list;
        }

        private static void OnValidateFTPSCertificate(FtpClient control, FtpSslValidationEventArgs e)
        {
            if (_allowTestCertificates.ToLower() == "true") // Allow test certs only if allowed in app.config
                e.Accept = true;
        }

        private static List<string> GetFileListFromSFTP(Agent sftpagent)
        {
            List<string> list = new List<string>();

            try
            {
                _log.Info("Connecting to host: {0}", sftpagent.Url);
                SftpClient client = new SftpClient(sftpagent.Url, sftpagent.Username, Encryption.Decrypt(sftpagent.Password, _encryptionKey));
                client.Connect();
                _log.Info("Connected, server version: {0}", client.ConnectionInfo.ServerVersion);

                IEnumerable<SftpFile> fileList = client.ListDirectory(sftpagent.Directory);
                foreach (SftpFile file in fileList)
                {
                    if (file.Name.IsLike(sftpagent.FilePattern))
                        list.Add(file.FullName);
                }

                client.Disconnect();
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Unexpected exception in GetFileListFromSFTP()");
            }

            return list;
        }

        private static bool DoesFileExistInLog(int agentId, string file)
        {
            bool fileFound = false;

            using (DataFlowDbContext ctx = new DataFlowDbContext())
            {
                int fileCount = ctx.Files
                    .Where(f => f.AgentId == agentId)
                    .Where(f => f.FileName == file)
                    .Count();

                if (fileCount == 0) { fileFound = false; } else { fileFound = true; }
            }

            _log.Info("DoesFileExistInLog: {0} is: {1}", file, fileFound.ToString());

            return fileFound;
        }

        private static void TransferFileToStorage(Agent agent, string file)
        {
            MemoryStream stream = null;
            switch (agent.AgentTypeCode)
            {
                case AgentTypeCodeEnum.SFTP:
                    stream = TransferFileFromSFTP(agent, file);
                    break;
                case AgentTypeCodeEnum.FTPS:
                    stream = TransferFileFromFTPS(agent, file);
                    break;
                default:
                    throw new NotImplementedException("Unexpected agent type provided to TransferFileToStorage");
            }

            if (stream != null)
            {
                switch (_fileMode)
                {
                    case FileModeEnum.Azure:
                        TransferFileToAzure(stream, file, agent);
                        break;
                    case FileModeEnum.Local:
                        TransferFileToLocal(stream, file, agent);
                        break;
                    default:
                        throw new NotImplementedException("Unexpected file mode provided to TransferFileToStorage");
                }

            }
        }

        private static MemoryStream TransferFileFromSFTP(Agent sftpagent, string file)
        {
            SftpClient client = new SftpClient(sftpagent.Url, sftpagent.Username, Encryption.Decrypt(sftpagent.Password, _encryptionKey));
            client.Connect();
            MemoryStream stream = new MemoryStream();
            client.DownloadFile(file, stream);
            return stream;
        }

        private static MemoryStream TransferFileFromFTPS(Agent ftpsagent, string file)
        {
            MemoryStream stream = new MemoryStream();
            FtpClient client = new FtpClient(ftpsagent.Url, ftpsagent.Username, Encryption.Decrypt(ftpsagent.Password, _encryptionKey));
            client.EncryptionMode = FtpEncryptionMode.Implicit; // Only implicit FTPS on port 990
            client.ValidateCertificate += new FtpSslValidation(OnValidateFTPSCertificate);
            client.Connect();

            client.Download(stream, file);

            return stream;
        }

        private static void TransferFileToAzure(MemoryStream stream, string file, Agent agent)
        {
            string shortFileName = file.Substring(file.LastIndexOf('/') + 1);
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_azureFileConnectionString);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare fileShare = fileClient.GetShareReference(_shareName);

            if (!fileShare.Exists())
                _log.Error("Azure file share does not exist as expected.  Connection string: {0}", _azureFileConnectionString);
            else
            {
                try
                {
                    CloudFileDirectory fileDirectoryRoot = fileShare.GetRootDirectoryReference();
                    CloudFileDirectory fileAgentDirectory = fileDirectoryRoot.GetDirectoryReference(agent.Queue.ToString());
                    fileAgentDirectory.CreateIfNotExists();
                    CloudFile cloudFile = fileAgentDirectory.GetFileReference(shortFileName);
                    stream.Seek(0, SeekOrigin.Begin);
                    cloudFile.UploadFromStream(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    int recordCount = TotalLines(stream);

                    LogFile(agent.Id, file, cloudFile.StorageUri.PrimaryUri.ToString(), FileStatusEnum.UPLOADED, recordCount);
                    _log.Info("Successfully transfered file {0} to {1} by agent ID: {2}", shortFileName, cloudFile.StorageUri.PrimaryUri.ToString(), agent.Id.ToString());
                }
                catch (Exception ex)
                {
                    _log.Error(ex, "Unexpected error in TransferFileToAzure for file: {0} on site: ", agent.Url);
                    LogFile(agent.Id, file, "", FileStatusEnum.ERROR_UPLOADED, 0);
                }
            }
        }

        private static void TransferFileToLocal(MemoryStream stream, string file, Agent agent)
        {
            try
            {
                string shortFileName = file.Substring(file.LastIndexOf('/') + 1);
                string localPath = EnsureTrailingSlash(_shareName) + agent.Queue.ToString();
                string localFilePath = EnsureTrailingSlash(localPath) + shortFileName;
                Uri localFileUri = new Uri(localFilePath);

                if (!System.IO.Directory.Exists(localPath))
                    System.IO.Directory.CreateDirectory(localPath);

                FileStream fileStream = System.IO.File.Create(localFilePath);
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
                fileStream.Close();

                stream.Seek(0, SeekOrigin.Begin);
                int recordCount = TotalLines(stream);

                LogFile(agent.Id, file, localFileUri.AbsoluteUri, FileStatusEnum.UPLOADED, recordCount);
                _log.Info("Successfully transfered file {0} to {1} by agent ID: {2}", shortFileName, localFileUri.AbsoluteUri, agent.Id);
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Unexpected error in TransferFileToLocal for file: {0} on site: {1}", file, agent.Url);
                LogFile(agent.Id, file, "", FileStatusEnum.ERROR_UPLOADED, 0);
            }


        }

        private static bool HaveConfigurationValues()
        {
            bool haveConfig = false;

            if (_connectionString == null || _fileMode == null || _encryptionKey == null || _shareName == null)
                _log.Error("Default SQL configuration, File Mode, Share Name or Encryption Key is not specified, please update App.config.");
            else
                haveConfig = true;

            if (_fileMode == FileModeEnum.Local)
                _shareName = EnsureTrailingSlash(_shareName);

            return haveConfig;
        }

        private static void LogFile(int agentId, string fileName, string URL, string status, int rows)
        {
            using (DataFlowDbContext ctx = new DataFlowDbContext())
            {
                Models.File fileLog = new Models.File();
                fileLog.AgentId = agentId;
                fileLog.FileName = fileName;
                fileLog.Url = URL;
                fileLog.Rows = rows;
                fileLog.Status = status;
                fileLog.CreateDate = DateTime.Now;
                ctx.Files.Add(fileLog);
                ctx.SaveChanges();
            }
        }

        private static int TotalLines(Stream stream)
        {
            using (StreamReader r = new StreamReader(stream))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }

        private static string EnsureTrailingSlash(string path)
        {
            if (path.Substring(path.Length - 1, 1) != @"\")
                path += @"\";

            return path;
        }

        public static bool ShouldExecuteOnSchedule(Agent agent, DateTime? nowDate = null)
        {
            if (!nowDate.HasValue)
                nowDate = DateTime.Now;

            bool shouldRun = false;


            if (agent.AgentSchedules.Count > 0)
            {
                int nowDay = (int)nowDate.Value.DayOfWeek;
                int nowHour = nowDate.Value.Hour;
                int nowMinute = nowDate.Value.Minute;

                IEnumerable<AgentSchedule> sortedSchedule = from schedules in agent.AgentSchedules
                                                            orderby schedules.Day ascending, schedules.Hour ascending, schedules.Hour ascending
                                                            select schedules;

                foreach (AgentSchedule schedule in sortedSchedule)
                {
                    DateTime scheduleDateTime = DateTime.Parse(nowDate.Value.ToShortDateString() + " " + schedule.Hour + ":" + schedule.Minute);
                    scheduleDateTime = scheduleDateTime.AddDays(-((int)nowDate.Value.DayOfWeek - schedule.Day));

                    if (!agent.LastExecuted.HasValue || scheduleDateTime > agent.LastExecuted)
                    {
                        if (schedule.Day <= nowDay)
                        {
                            if (schedule.Hour < nowHour)
                                shouldRun = true;
                            else if (schedule.Hour == nowHour && schedule.Minute <= nowMinute)
                                shouldRun = true;
                        }
                    }
                }
            }

            return shouldRun;
        }

    }
}
