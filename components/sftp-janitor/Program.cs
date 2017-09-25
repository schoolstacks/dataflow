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

            if (connectionString == null)
            {
                _log.Error("Default SQL configuration is not specified.");
            } else
            {
                SqlConnection conn = new SqlConnection(connectionString);
                _log.Info("Connecting to database: " + conn.Database);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dataflow].[agent] WHERE Enabled=1", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SFTPAgent agent = SFTPAgent.GetInstance((string)reader["Name"], (string)reader["URL"], (string)reader["Username"], (string)reader["Password"], (string)reader["Directory"], (string)reader["FilePattern"]);

                    _log.Info("Processing agent name: " + agent.Name);

                    List<string> fileList = GetFileListFromSFTP(agent);

                    _log.Info("Items to process:" + fileList.Count.ToString());

                }
            }

            //TestsFTP();
            //WriteLocalFilesToAzureFileStorage();
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

        private static void GetFileFromSFTP()
        {
            //TODO:  implement

            //string filename = @".\" + file.Name;
            //Stream fileStream = File.OpenWrite(filename);
            //client.DownloadFile(file.FullName, fileStream);
            //fileStream.Close();
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

        private static String WildCardToRegular(String value)
        {
            return "^" + Regex.Escape(value).Replace("\\*", ".*") + "$";
        }

    }
}
