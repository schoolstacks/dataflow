using System;
using System.Collections.Generic;
using System.IO;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace sftp_janitor
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
