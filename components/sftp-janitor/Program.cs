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
            } else
            {
                SqlConnection conn = new SqlConnection(connectionString);
                _log.Info("Connecting to database: " + conn.Database);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dataflow].[agent] WHERE Enabled=1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SFTPAgent agent = SFTPAgent.GetInstance((string)reader["Name"], (string)reader["URL"], (string)reader["Username"], (string)reader["Password"], (string)reader["Directory"], (string)reader["FilePattern"], (System.Guid)reader["Queue"]);

                    _log.Info("Processing agent name: " + agent.Name);
                    List<string> fileList = GetFileListFromSFTP(agent);
                    _log.Info("Items to process:" + fileList.Count.ToString());
                    TransferFilesFromSFTPToAzure(agent, azureFileConnectionString, fileList);

                    SqlCommand cmdUpdate = new SqlCommand("UPDATE [dataflow].[agent] SET LastExecuted=@LastExecuted WHERE ID=@ID", conn);
                    cmdUpdate.Parameters.AddWithValue("@LastExecuted", DateTime.Now);
                    cmdUpdate.Parameters.AddWithValue("@ID", (int)reader["ID"]);
                    cmdUpdate.ExecuteNonQuery();
                }
            }

            _log.Info("SFTP Janitor exiting");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

        }

        private static List<string> GetFileListFromSFTP(SFTPAgent agent)
        {
            List<string> list = new List<string>();

            try
            {
                _log.Info("Connecting to host: " + agent.URL);
                SftpClient client = new SftpClient(agent.URL, agent.Username, agent.Password);
                client.Connect();
                _log.Info("Connected, server version: " + client.ConnectionInfo.ServerVersion);

                IEnumerable<SftpFile> fileList = client.ListDirectory(agent.Directory);
                foreach (SftpFile file in fileList)
                {
                    Boolean containsFilePattern = Regex.IsMatch(file.Name, WildCardToRegular(agent.FilePattern));
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

        private static void TransferFilesFromSFTPToAzure(SFTPAgent agent, string azureFileConnectionString, List<string> fileList)
        {
            foreach (string file in fileList)
            {
                string shortFileName = file.Substring(file.LastIndexOf('/') + 1);
                SftpClient client = new SftpClient(agent.URL, agent.Username, agent.Password);
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
                        CloudFileDirectory fileAgentDirectory = fileDirectoryRoot.GetDirectoryReference(agent.Queue.ToString());
                        fileAgentDirectory.CreateIfNotExists();
                        CloudFile cloudFile = fileAgentDirectory.GetFileReference(shortFileName);
                        cloudFile.UploadFromStream(stream);

                        //TODO:  Log file success in log_ingestion   
                    }
                    catch (Exception ex)
                    {
                        _log.Error("Unexpected error in TransferFilesFromSFTPToAzure for file: " + file + " on site: " + agent.URL, ex);
                        //TODO:  Log file error in log_ingestion
                    }          
                }
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
