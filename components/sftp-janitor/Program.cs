using System;
using System.Collections.Generic;
using System.IO;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.File;
using System.Linq;

namespace sftp_janitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestsFTP();
            //ListFiles();
            WriteLocalFilesToAzureFileStorage();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void TestsFTP()
        {
            string host;
            string username;
            string password;

            host = "test.rebex.net";
            username = "demo";
            password = "password";

            try
            {
                SftpClient client = new SftpClient(host, username, password);
                client.Connect();
                Console.WriteLine(client.ConnectionInfo.ServerVersion);

                IEnumerable<SftpFile> fileList = client.ListDirectory("/");
                foreach (SftpFile file in fileList)
                {
                    Console.WriteLine(file.FullName);

                    if (file.Name.Contains(".txt"))
                    {
                        string filename = @".\" + file.Name;
                        Stream fileStream = File.OpenWrite(filename);
                        client.DownloadFile(file.FullName, fileStream);
                        fileStream.Close();
                    }


                }

                client.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void ListFiles()
        {
            //Check https://docs.microsoft.com/en-us/azure/storage/files/storage-dotnet-how-to-use-files
            // Parse the connection string and return a reference to the storage account.
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //    CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                Properties.Settings.Default.StorageConnectionString);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare fileShare = fileClient.GetShareReference(Properties.Settings.Default.FileShareName);
            CloudFileDirectory fileDirectoryRoot = fileShare.GetRootDirectoryReference();
            var allItems = fileDirectoryRoot.ListFilesAndDirectories();
            var allRootDirectories = allItems.OfType<CloudFileDirectory>();
            var allRootFiles = allItems.OfType<CloudFile>();
            foreach (CloudFileDirectory singleDirectory in allRootDirectories)
            {
                Console.WriteLine(singleDirectory.Uri.ToString());
                var currentDirectoryFiles = singleDirectory.ListFilesAndDirectories().OfType<CloudFile>();
                foreach (var singleFile in currentDirectoryFiles)
                {
                    Console.WriteLine(singleFile.Uri);
                    string dir = Properties.Settings.Default.LocalDestinationDirectory;
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    string localFile = System.IO.Path.Combine(dir, singleFile.Parent.Name, singleFile.Name);
                    var localDir = Path.GetDirectoryName(localFile);
                    if (!Directory.Exists(localDir))
                        Directory.CreateDirectory(localDir);
                    singleFile.DownloadToFile(localFile, FileMode.Create);
                }
            }
            foreach (CloudFile singleFile in allRootFiles)
            {
                Console.WriteLine(singleFile.Uri.ToString());
                using (var strReader = singleFile.OpenRead())
                {
                    string strFileContent = singleFile.DownloadText();
                    Console.WriteLine("**********START OF {0}**********", singleFile.Name);
                    Console.WriteLine(strFileContent);
                    Console.WriteLine("**********END OF {0}**********", singleFile.Name);
                    strReader.Close();
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
    }
}
