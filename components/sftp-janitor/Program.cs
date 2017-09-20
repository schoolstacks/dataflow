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
