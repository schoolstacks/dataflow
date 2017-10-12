using System;
using System.Collections.Generic;
using System.IO;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.File;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using server_components_data_access.Dataflow;
using System.Data.Entity;

namespace sftp_janitor
{
    class Program
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            _log.Info("SFTP Janitor starting");
            string connectionString = GetSQLConnectionString();
            string azureFileConnectionString = GetAzureFileConnectionString();

            if (connectionString == null || azureFileConnectionString == null)
            {
                _log.Error("Default SQL configuration or Azure File connection is not specified.");
            }
            else
            {
                using (DataFlowContext ctx = new DataFlowContext())
                {
                    var agents = ctx.agents.Where(agent => agent.Enabled == true);

                    foreach (var sftpagent in agents)
                    {
                        Console.WriteLine(sftpagent.Name);
                        _log.Info("Processing agent name: " + sftpagent.Name);

                        List<string> fileList = GetFileListFromSFTP(sftpagent);
                        _log.Info("Items to process:" + fileList.Count.ToString());
                        TransferFilesFromSFTPToAzure(sftpagent, azureFileConnectionString, fileList);

                        sftpagent.LastExecuted = DateTime.Now;
                    }

                    ctx.SaveChanges();
                }
            }
        }

        private static List<string> GetFileListFromSFTP(agent sftpagent)
        {
            List<string> list = new List<string>();

            try
            {
                _log.Info("Connecting to host: " + sftpagent.URL);
                SftpClient client = new SftpClient(sftpagent.URL, sftpagent.Username, sftpagent.Password);
                client.Connect();
                _log.Info("Connected, server version: " + client.ConnectionInfo.ServerVersion);

                IEnumerable<SftpFile> fileList = client.ListDirectory(sftpagent.Directory);
                foreach (SftpFile file in fileList)
                {
                    Boolean containsFilePattern = Regex.IsMatch(file.Name, WildCardToRegular(sftpagent.FilePattern));
                    if (containsFilePattern) { list.Add(file.FullName); }
                }

                client.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return list;
        }

        private static void TransferFilesFromSFTPToAzure(agent sftpagent, string azureFileConnectionString, List<string> fileList)
        {
            foreach (string file in fileList)
            {
                string shortFileName = file.Substring(file.LastIndexOf('/') + 1);
                SftpClient client = new SftpClient(sftpagent.URL, sftpagent.Username, sftpagent.Password);
                client.Connect();
                MemoryStream stream = new MemoryStream();
                client.DownloadFile(file, stream);
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(azureFileConnectionString);
                CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
                CloudFileShare fileShare = fileClient.GetShareReference(Properties.Settings.Default.FileShareName);

                if (!fileShare.Exists())
                {
                    _log.Error("Azure file share does not exist as expected.");
                } else
                {

                    try
                    {
                        CloudFileDirectory fileDirectoryRoot = fileShare.GetRootDirectoryReference();
                        CloudFileDirectory fileAgentDirectory = fileDirectoryRoot.GetDirectoryReference(sftpagent.Queue.ToString());
                        fileAgentDirectory.CreateIfNotExists();
                        CloudFile cloudFile = fileAgentDirectory.GetFileReference(shortFileName);
                        stream.Seek(0, SeekOrigin.Begin);
                        cloudFile.UploadFromStream(stream);
                        stream.Seek(0, SeekOrigin.Begin);
                        int recordCount = TotalLines(stream);

                        using (DataFlowContext ctx = new DataFlowContext())
                        {
                            log_ingestion log = new log_ingestion();
                            log.AgentID = sftpagent.ID;
                            log.Date = DateTime.UtcNow;
                            log.Result = "SUCCESS";
                            log.Message = "File successfully updated: " + file;
                            log.Filename = cloudFile.StorageUri.PrimaryUri.ToString();
                            log.Operation = "SFTPFileTransfer";
                            log.Process = "sftp-janitor";
                            log.Level = "INFO";
                            log.RecordCount = recordCount;
                            ctx.log_ingestion.Add(log);
                            ctx.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        _log.Error("Unexpected error in TransferFilesFromSFTPToAzure for file: " + file + " on site: " + sftpagent.URL, ex);
                        using (DataFlowContext ctx = new DataFlowContext())
                        {
                            log_ingestion log = new log_ingestion();
                            log.AgentID = sftpagent.ID;
                            log.Date = DateTime.UtcNow;
                            log.Result = "ERROR";
                            log.Filename = file;
                            log.Message = "File failed with the error message: " + ex.ToString();
                            log.Operation = "SFTPFileTransfer";
                            log.Process = "sftp-janitor";
                            log.Level = "ERROR";
                            ctx.log_ingestion.Add(log);
                            ctx.SaveChanges();
                        }
                        //TODO:  Log file error in log_ingestion
                    }          
                }
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


        private static void WriteLocalFilesToAzureFileStorage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                Properties.Settings.Default.StorageConnectionString);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare fileShare = fileClient.GetShareReference(Properties.Settings.Default.FileShareName);
            CloudFileDirectory fileDirectoryRoot = fileShare.GetRootDirectoryReference();
            DirectoryInfo sourceDirInfo = new DirectoryInfo(Properties.Settings.Default.LocalSourceDirectory);
            foreach (var singleFileInfo in sourceDirInfo.GetFiles())
            {
                var cloudFile = fileDirectoryRoot.GetFileReference(singleFileInfo.Name);
                cloudFile.UploadFromFile(singleFileInfo.FullName);
            }
        }

        private static string GetSQLConnectionString()
        {
            if (Environment.GetEnvironmentVariable("SQLAZURECONNSTR_defaultConnection") != null)
            {
                return Environment.GetEnvironmentVariable("SQLAZURECONNSTR_defaultConnection");
            } else
            {
                _log.Error("Environment variable (SQLAZURECONNSTR_defaultConnection) for default connection is not defined.");
            }

            return null;
        }

        private static string GetAzureFileConnectionString()
        {
            if (Environment.GetEnvironmentVariable("CUSTOMCONNSTR_storageConnection") != null)
            {
                return Environment.GetEnvironmentVariable("CUSTOMCONNSTR_storageConnection");
            }
            else
            {
                _log.Error("Environment variable (CUSTOMCONNSTR_storageConnection) for default connection is not defined.");
            }

            return null;
        }

        private static String WildCardToRegular(String value)
        {
            return "^" + Regex.Escape(value).Replace("\\*", ".*") + "$";
        }

    }
}
