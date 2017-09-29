using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using transform_api_load_janitor.DataMaps.Interfaces;
using transform_api_load_janitor.DataMaps.Student;
using server_components_data_access.Dataflow;
using CsvHelper;

namespace transform_api_load_janitor
{
    class Program
    {
        private static List<server_components_data_access.Dataflow.datamap> DataMapsList { get; set; } = null;
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            StartProcessing();
            //LoadDataflowConfiguration();
            //TransformFilesFromAzureFileStorage();
            watch.Stop();
            Console.WriteLine("Time Elapsed: {0}", watch.Elapsed.ToString());
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void StartProcessing()
        {
            using (server_components_data_access.Dataflow.DataFlowContext ctx =
                new server_components_data_access.Dataflow.DataFlowContext())
            {
                var agents = ctx.agents.Include("datamap_agent").Include("datamap_agent.datamap").ToList();
                foreach (var singleAgent in agents)
                {
                    foreach (var singleDataMapAgent in singleAgent.datamap_agent.OrderBy(p => p.ProcessingOrder))
                    {
                        var entity = singleDataMapAgent.datamap.entity;
                        ProcessEntity(entity: entity, dataMap: singleDataMapAgent.datamap, cloudFileUrl: "https://dataflow.file.core.windows.net/sample-files/set02/mcl-progress-monitoring.csv");
                    }
                }
            }
        }


        private static void ProcessEntity(entity entity, datamap dataMap, string cloudFileUrl)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
    Properties.Settings.Default.StorageConnectionString);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare fileShare = fileClient.GetShareReference(Properties.Settings.Default.FileShareName);
            CloudFile file = new CloudFile(new Uri(cloudFileUrl), storageAccount.Credentials);
            string strFileText = file.DownloadText();
            using (StringReader strReader = new StringReader(strFileText))
            {
                using (CsvHelper.CsvReader reader = new CsvHelper.CsvReader(strReader))
                {
                    while (reader.Read())
                    {
                        JToken generatedRow = ProcessCSVRow(entity, dataMap, reader);
                    }
                }

            }

        }

        private static JToken ProcessCSVRow(entity entity, datamap dataMap, CsvReader reader)
        {
            JToken originalMap = JToken.Parse(dataMap.Map);
            JToken result = originalMap.DeepClone();
            TransformCSVRow(originalMap, ref result, reader);
            return result;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("An unhandled exception has occurred: " + ((Exception)e.ExceptionObject).ToString());
        }

        private static void TransformCSVRow(JToken originalMap, ref JToken outputData, CsvReader reader)
        {
            var jChildrenProperties = originalMap.Children<JProperty>();
            string[] mappinHints = { "data-type", "source", "source-column" };
            bool hasMappingHints = jChildrenProperties.Any(p => mappinHints.Contains(p.Name));
            if (hasMappingHints)
            {
                var dataTypeField = jChildrenProperties.Where(p => p.Name == "data-type").FirstOrDefault();
                var sourceField = jChildrenProperties.Where(p => p.Name == "source").FirstOrDefault();
                var sourceColumnField = jChildrenProperties.Where(p => p.Name == "source-column").FirstOrDefault();
                if (sourceField != null)
                {
                    switch (sourceField.Value.ToString())
                    {
                        case "column":
                            string csvColumnName = sourceColumnField.Value.ToString();
                            string csvValue = reader[csvColumnName];
                            outputData[originalMap.Parent.Path] = csvValue;
                            break;
                        case "lookup_table":
                            outputData[originalMap.Parent.Path] = "NOT IMPLEMENTED";
                            break;
                    }
                }
            }
            else
            {
                foreach (var jSingleProperty in jChildrenProperties)
                {
                    foreach (var jSingleChild in jSingleProperty.Children())
                    {
                        TransformCSVRow(jSingleChild, ref outputData, reader);
                    }
                }
            }
        }

        private static void TransformFile(string filePath)
        {
            using (System.IO.StreamReader textReader = new System.IO.StreamReader(filePath))
            {
                using (CsvHelper.CsvReader csvReader = new CsvHelper.CsvReader(textReader))
                {
                    bool isFirstRow = true;
                    int rowNumber = 0;
                    while (csvReader.Read())
                    {
                        Console.WriteLine("Start of Data for Row: {0}", rowNumber);
                        for (int iCol = 0; iCol < csvReader.CurrentRecord.Length; iCol++)
                        {
                            string columnName = csvReader.FieldHeaders[iCol];
                            string columnValue = csvReader.GetField(iCol);
                            Console.WriteLine("{0} = {1}", columnName, columnValue);
                        }
                        Console.WriteLine("End of Data for Row: {0}", rowNumber);
                        rowNumber++;
                    }
                }
            }
        }

        private static void TransformFilesFromAzureFileStorage()
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
                    var extension = Path.GetExtension(singleFile.Name).ToUpper();
                    if (extension != ".CSV")
                        continue;
                    Console.WriteLine(singleFile.Uri);
                    string dir = Properties.Settings.Default.LocalDestinationDirectory;
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    string localFile = System.IO.Path.Combine(dir, singleFile.Parent.Name, singleFile.Name);
                    var localDir = Path.GetDirectoryName(localFile);
                    if (!Directory.Exists(localDir))
                        Directory.CreateDirectory(localDir);
                    singleFile.DownloadToFile(localFile, FileMode.Create);
                    try
                    {
                        TransformFile(localFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
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
    }
}
