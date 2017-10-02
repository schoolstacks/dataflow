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
using System.Net.Http;

namespace transform_api_load_janitor
{
    class Program
    {
        private static List<server_components_data_access.Dataflow.datamap> DataMapsList { get; set; } = null;
        static void Main(string[] args)
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                var tsk = StartProcessing();
                tsk.Wait();
                //LoadDataflowConfiguration();
                //TransformFilesFromAzureFileStorage();
                watch.Stop();
                Console.WriteLine("Time Elapsed: {0}", watch.Elapsed.ToString());
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            catch (AggregateException ex)
            {

            }
        }

        private static List<server_components_data_access.Dataflow.lookup> MappingLookups { get; set; }
        private static List<KeyValuePair<string, string>> InsertedIds { get; set; } = new List<KeyValuePair<string, string>>();

        private static async Task StartProcessing()
        {
            using (server_components_data_access.Dataflow.DataFlowContext ctx =
                new server_components_data_access.Dataflow.DataFlowContext())
            {
                List<server_components_data_access.Dataflow.log_ingestion> lstIngestionMessages = new List<log_ingestion>();
                var agents = ctx.agents.Include("datamap_agent").Include("datamap_agent.datamap").ToList();
                MappingLookups = ctx.lookups.ToList();
                foreach (var singleAgent in agents)
                {
                    foreach (var singleDataMapAgent in singleAgent.datamap_agent.OrderBy(p => p.ProcessingOrder))
                    {
                        var entity = singleDataMapAgent.datamap.entity;
                        ProcessEntity(entity: entity, dataMap: singleDataMapAgent.datamap, cloudFileUrl: "https://dataflow.file.core.windows.net/sample-files/set02/mcl-progress-monitoring.csv");
                    }
                }
                string authorizeUrl = GetAuthorizeUrl();
                string accessTokenUrl = GetAccessTokenUrl();
                string clientId = GetApiClientId();
                string clientSecret = GetApiClientSecret();
                string authCode = await RetrieveAuthorizationCode(authorizeUrl, clientId: clientId);
                string accessToken = await RetrieveAccessToken(accessTokenUrl, clientId, clientSecret, authCode);
                Console.WriteLine("Start of Api Insertion: {0} records", ApiData.Count);
                int iCurrentRecord = 1;
                foreach (var singleApiData in ApiData)
                {
                    if (String.IsNullOrWhiteSpace(singleApiData.Key.Metadata))
                    {
                        lstIngestionMessages.Add(new log_ingestion()
                        {
                            Date = DateTime.UtcNow,
                            //Filename = singleApiData.Key
                            Result = "ERROR",
                            Message = string.Format("Entity has no Metadata. Entity ID: {0}", singleApiData.Key.ID),
                            Level = "ERROR",
                            Operation = "TransformingData",
                            Process = "transform-api-load-janitor"
                        });
                        continue; // we will not process if we cannot read metadata
                    }
                    Console.WriteLine("Api Insertion Record: {0} of {1}", iCurrentRecord, ApiData.Count);
                    iCurrentRecord++;
                    string endpointUrl = RetrieveEndpointUrlFromMetadata(singleApiData.Key.Metadata);
                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                        string strId = string.Empty;
                        string strIdName = string.Empty;
                        switch (singleApiData.Key.Name)
                        {
                            case "students":
                                strIdName = "studentUniqueId";
                                strId = singleApiData.Value[strIdName].ToString();
                                break;
                            default:
                                break;
                        }
                        StringContent strContent = new StringContent(singleApiData.Value.ToString());
                        strContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        HttpResponseMessage response = null;
                        if (!string.IsNullOrWhiteSpace(strIdName) && !string.IsNullOrWhiteSpace(strId))
                        {
                            var recordExistsResult = await RecordExists(strIdName, strId, endpointUrl, accessToken);
                            if (recordExistsResult.Key == false)
                                response = await httpClient.PostAsync(endpointUrl, strContent);
                            else
                            {
                                endpointUrl += string.Format("?{0}={1}", strIdName, recordExistsResult.Value);
                                response = await httpClient.PutAsync(endpointUrl, strContent);
                            }
                        }
                        switch (response.StatusCode)
                        {
                            case System.Net.HttpStatusCode.OK:
                                break;
                            case System.Net.HttpStatusCode.Created:
                                Console.WriteLine("Data Inserted on endpoint: {0}", endpointUrl);
                                InsertedIds.Add(new KeyValuePair<string, string>(strIdName, strId));
                                lstIngestionMessages.Add(new log_ingestion()
                                {
                                    Date = DateTime.UtcNow,
                                    //Filename = singleApiData.Key
                                    Result = "SUCCESS",
                                    Message = string.Format("Record Created:\r\nData:\r\n{0}", singleApiData.Value.ToString()),
                                    Level = "INFORMATION",
                                    Operation = "TransformingData",
                                    Process = "transform-api-load-janitor"
                                });
                                break;
                            default:
                                string strError = await response.Content.ReadAsStringAsync();
                                var singleIngestionError =
                                    new log_ingestion()
                                    {
                                        Date = DateTime.UtcNow,
                                        //Filename = singleApiData.Key
                                        Result = "ERROR",
                                        Message = string.Format("Message: {0}\r\nData:\r\n{1}", strError, singleApiData.Value.ToString()),
                                        Level = "ERROR",
                                        Operation = "TransformingData",
                                        Process = "transform-api-load-janitor"
                                    };
                                lstIngestionMessages.Add(singleIngestionError);
                                break;
                        }
                    }
                    if (lstIngestionMessages.Count > 0)
                    {
                        try
                        {
                            lstIngestionMessages.ForEach((singleIngestionError) =>
                            {
                                ctx.log_ingestion.Add(singleIngestionError);
                            });
                            ctx.SaveChanges();
                            lstIngestionMessages.Clear();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
        }

        private static async Task<KeyValuePair<bool, string>> RecordExists(string strIdName, string strId, string endpointUrl, string accessToken)
        {
            bool result = false;
            string recordId = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                string endpontUrlWithQueryString = endpointUrl + String.Format("?{0}={1}", strIdName, strId);
                var response = await httpClient.GetAsync(endpontUrlWithQueryString);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        result = true;
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        var jToken = JToken.Parse(jsonResult);
                        recordId = jToken[strIdName].Value<string>();
                        break;
                }
            }
            return new KeyValuePair<bool, string>(result, recordId);
        }

        private static string GetEnvironmentVariable(string name)
        {
            return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
        }

        private static string GetApiBaseUrl()
        {
            return GetEnvironmentVariable("CloudOdsApiBaseUrl");
        }
        private static string GetAccessTokenUrl()
        {
            string baseUrl = GetApiBaseUrl();
            return baseUrl + "/oauth/token";
        }

        private static string GetAuthorizeUrl()
        {
            string baseUrl = GetApiBaseUrl();
            return baseUrl + "/oauth/authorize";
        }

        private static string GetApiClientSecret()
        {
            return GetEnvironmentVariable("CloudOdsApiClientSecret");
        }

        private static string GetApiClientId()
        {
            return GetEnvironmentVariable("CloudOdsApiClientId");
        }

        private static string RetrieveEndpointUrlFromMetadata(string metadata)
        {
            string strUrl = string.Empty;
            try
            {
                JToken swaggerMetaData = JToken.Parse(metadata);
                //string basePath = swaggerMetaData["basePath"].Value<string>();
                string basePath = GetApiBaseUrl() + "/api/v2.0/2017";
                string resourcePath = swaggerMetaData["resourcePath"].Value<string>();
                strUrl = string.Format("{0}{1}", basePath, resourcePath);
            }
            catch (Exception ex)
            {

            }
            return strUrl;
        }

        private static async Task<string> RetrieveAccessToken(string accessTokenUrl, string clientId, string clientSecret, string authCode)
        {
            string accessToken = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                List<KeyValuePair<string, string>> lstParams = new List<KeyValuePair<string, string>>();
                lstParams.Add(new KeyValuePair<string, string>("Client_id", clientId));
                lstParams.Add(new KeyValuePair<string, string>("Client_secret", clientSecret));
                lstParams.Add(new KeyValuePair<string, string>("Code", authCode));
                lstParams.Add(new KeyValuePair<string, string>("Grant_type", "authorization_code"));
                FormUrlEncodedContent contentParams = new FormUrlEncodedContent(lstParams);
                var result = await httpClient.PostAsync(accessTokenUrl, contentParams);
                switch (result.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var jsonResult = await result.Content.ReadAsStringAsync();
                        var jsonToken = JToken.Parse(jsonResult);
                        accessToken = jsonToken["access_token"].ToString();
                        break;
                    default:
                        break;
                }
            }
            return accessToken;
        }

        private static async Task<string> RetrieveAuthorizationCode(string authorizeUrl, string clientId)
        {
            string code = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                List<KeyValuePair<string, string>> lstParameters = new List<KeyValuePair<string, string>>();
                lstParameters.Add(new KeyValuePair<string, string>("Client_id", clientId));
                lstParameters.Add(new KeyValuePair<string, string>("Response_type", "code"));
                FormUrlEncodedContent contentParams = new FormUrlEncodedContent(lstParameters);
                var result = await httpClient.PostAsync(authorizeUrl, contentParams);
                switch (result.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var jsonResponse = await result.Content.ReadAsStringAsync();
                        var jsonToken = JToken.Parse(jsonResponse);
                        code = jsonToken["code"].ToString();
                        break;
                    default:
                        throw new Exception(result.ReasonPhrase);
                        break;
                }
            }
            return code;
        }

        public static List<KeyValuePair<entity, JToken>> ApiData = new List<KeyValuePair<entity, JToken>>();


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
                        ApiData.Add(
                            new KeyValuePair<entity, JToken>(entity, generatedRow)
                            );
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
                var sourceTable = jChildrenProperties.Where(p => p.Name == "source-table").FirstOrDefault();
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
                            //outputData[originalMap.Parent.Path] = "NOT IMPLEMENTED";
                            outputData[originalMap.Parent.Path] = GetValueFromLookupTable(sourceTable.Value.ToString(), sourceColumnField.Value.ToString(), reader);
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

        private static string GetValueFromLookupTable(string lookupTable, string lookupColumn, CsvReader csvRow)
        {
            string result = string.Empty;
            string valueInCSV = csvRow[lookupColumn];
            var matchingRecord = MappingLookups.Where(p => p.GroupSet == lookupTable && p.Key == valueInCSV).FirstOrDefault();
            if (matchingRecord != null)
                result = matchingRecord.Value;
            return result;
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
