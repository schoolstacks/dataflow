using System;
using System.Collections.Generic;
using System.IO;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System.Linq;
using System.Data;
using System.Text.RegularExpressions;
using server_components_data_access.Dataflow;
using server_components_data_access.Enums;

namespace DataFlow.Server.FileTransport
{
    class Program
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            _log.Info("File Transport Janitor starting");
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            string azureFileConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["storageConnection"].ConnectionString;

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
                        _log.Info("Processing agent name: " + sftpagent.Name);

                        List<string> fileList = GetFileListFromSFTP(sftpagent);
                        _log.Info("Items to process:" + fileList.Count.ToString());

                        foreach (string file in fileList)
                        {
                            _log.Info("Processing: " + file);
                            // Check the file log to see if the file already exists, if not, upload to Azure
                            if (!DoesFileExistInLog(sftpagent.ID, file)) {
                                TransferFileFromSFTPToAzure(sftpagent, azureFileConnectionString, file);
                            }
                        }

                        sftpagent.LastExecuted = DateTime.Now;
                    }

                    ctx.SaveChanges();
                }
            }

            _log.Info("File Transport Janitor exiting");
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
                _log.Error("Unexpected exception in GetFileListFromSFTP(): ", ex);
            }

            return list;
        }

        private static bool DoesFileExistInLog(int agentId, string file)
        {
            bool fileFound = false;

            using (DataFlowContext ctx = new DataFlowContext())
            {
                int fileCount = ctx.files
                    .Where(f => f.AgentID == agentId)
                    .Where(f => f.Filename == file)
                    .Count();

                if (fileCount == 0) { fileFound = false; } else { fileFound = true; }
            }

            _log.Info("DoesFileExistInLog: " + file + " is: " + fileFound.ToString());

            return fileFound;
        }

        private static void TransferFileFromSFTPToAzure(agent sftpagent, string azureFileConnectionString, string file)
        {
            string shortFileName = file.Substring(file.LastIndexOf('/') + 1);
            SftpClient client = new SftpClient(sftpagent.URL, sftpagent.Username, sftpagent.Password);
            client.Connect();
            MemoryStream stream = new MemoryStream();
            client.DownloadFile(file, stream);
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(azureFileConnectionString);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare fileShare = fileClient.GetShareReference(System.Configuration.ConfigurationManager.AppSettings["azureShareName"]);

            if (!fileShare.Exists())
            {
                _log.Error("Azure file share does not exist as expected.  Connection string: " + azureFileConnectionString);
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

                    LogFile(sftpagent.ID, file, cloudFile.StorageUri.PrimaryUri.ToString(), FileStatus.UPLOADED, recordCount);
                    _log.Info("Successfully transfered file " + shortFileName + " to " + cloudFile.StorageUri.PrimaryUri.ToString() + " by agent ID: " + sftpagent.ID.ToString());
                }
                catch (Exception ex)
                {
                    _log.Error("Unexpected error in TransferFilesFromSFTPToAzure for file: " + file + " on site: " + sftpagent.URL, ex);
                    LogFile(sftpagent.ID, file, "", FileStatus.ERROR_UPLOADED, 0);
                }          
            }

        }

        private static void LogFile(int agentId, string fileName, string URL, string status, int rows)
        {
            using (DataFlowContext ctx = new DataFlowContext())
            {
                file fileLog = new file();
                fileLog.AgentID = agentId;
                fileLog.Filename = fileName;
                fileLog.URL = URL;
                fileLog.Rows = rows;
                fileLog.Status = status;
                fileLog.CreateDate = DateTime.UtcNow;
                ctx.files.Add(fileLog);
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

        private static String WildCardToRegular(String value)
        {
            return "^" + Regex.Escape(value).Replace("\\*", ".*") + "$";
        }

    }
}
