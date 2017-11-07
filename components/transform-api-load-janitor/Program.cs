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
using System.Data.Entity.Core.EntityClient;
using server_components_data_access.Enums;
using log4net.Core;

namespace transform_api_load_janitor
{
    class Program
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static List<ResultingMapInfo> ApiData = new List<ResultingMapInfo>();
        private static List<server_components_data_access.Dataflow.datamap> DataMapsList { get; set; } = null;
        private const string DATAFLOW_CONNECTIONSTRINGKEY = "SQLAZURECONNSTR_defaultConnection";
        private static List<server_components_data_access.Dataflow.lookup> MappingLookups { get; set; }
        private static List<KeyValuePair<string, string>> InsertedIds { get; set; } = new List<KeyValuePair<string, string>>();
        static void Main(string[] args)
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                var config = log4net.Config.XmlConfigurator.Configure();
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                var tsk = StartProcessing();
                tsk.Wait();
                watch.Stop();

                Log(log4net.Core.Level.Info, "Time Elapsed: {0}", watch.Elapsed.ToString());
                Log(log4net.Core.Level.Info, "Press any key to continue");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Process Exception: " + ex.ToString());
                Log(log4net.Core.Level.Info, "AggregateException Exception");
                Log(log4net.Core.Level.Info, ex.ToString());
                foreach (var singleInnerException in ex.InnerExceptions)
                {
                    Log(log4net.Core.Level.Info, singleInnerException.ToString());
                }
            }
            finally
            {
                if (String.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME")))
                {
                    //if environment variable exists application is running under App Service. Otherwise is probably IIS or Visual Studio
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                }
            }
        }

        private static string GetDataFlowConnectionString()
        {
            return GetEnvironmentVariable(DATAFLOW_CONNECTIONSTRINGKEY);
        }
        private static EntityConnection BuildEntityConnection()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder sqlConnStringBuilder =
    new System.Data.SqlClient.SqlConnectionStringBuilder(GetDataFlowConnectionString());
            EntityConnectionStringBuilder entityConnStringBuilder = new EntityConnectionStringBuilder();
            entityConnStringBuilder.Metadata = "res://*/Dataflow.DataFlowContext.csdl|res://*/Dataflow.DataFlowContext.ssdl|res://*/Dataflow.DataFlowContext.msl";
            entityConnStringBuilder.ProviderConnectionString = sqlConnStringBuilder.ToString();
            entityConnStringBuilder.Provider = "System.Data.SqlClient";
            EntityConnection entityConn = new EntityConnection(entityConnStringBuilder.ToString());
            return entityConn;
        }
        private static async Task StartProcessing()
        {
            using (DataFlowContext ctx = new DataFlowContext(BuildEntityConnection()))
            {
                await InsertBootrapData(ctx);
                var agents = ctx.agents.Include("datamap_agent").Include("datamap_agent.datamap").ToList();
                MappingLookups = ctx.lookups.ToList();
                foreach (var singleAgent in agents)
                {
                    var dataMapAgents = singleAgent.datamap_agent.OrderBy(p => p.ProcessingOrder);
                    foreach (var singleFile in singleAgent.files.Where(p => p.Status.ToUpper() ==
                    FileStatus.UPLOADED))
                    {
                        Log(log4net.Core.Level.Info, "Processing file: {0}. URL: {1}", singleFile.Filename, singleFile.URL);
                        try
                        {
                            await ProcessDataMapAgent(dataMapAgents, cloudFileUrl: singleFile.URL, fileEntity: singleFile, ctx:ctx);
                        }
                        catch (Exception ex)
                        {
                            Log(log4net.Core.Level.Error, "Error processing file: {0}. Message: {1}", singleFile.URL, ex.ToString());
                        }

                        Log(log4net.Core.Level.Info, "Finished Processing file: {0}. URL: {1}", singleFile.Filename, singleFile.URL);
                    }
                }
            }
        }

        private static async Task PostTransformedData(DataFlowContext ctx)
        {
            List<log_ingestion> lstIngestionMessages = new List<log_ingestion>();
            string authorizeUrl = GetAuthorizeUrl(ctx);
            string accessTokenUrl = GetAccessTokenUrl(ctx);
            string clientId = GetApiClientId(ctx);
            string clientSecret = GetApiClientSecret(ctx);
            string authCode = await RetrieveAuthorizationCode(authorizeUrl, clientId: clientId);
            string accessToken = await RetrieveAccessToken(accessTokenUrl, clientId, clientSecret, authCode);
            Log(log4net.Core.Level.Info, "Start of Api Insertion: {0} records", ApiData.Count);
            int iCurrentRecord = 1;
            List<file> lstErroredFiles = new List<file>();
            iCurrentRecord = await ProcessApiData(ctx, lstIngestionMessages, accessToken, iCurrentRecord, lstErroredFiles);
            foreach (var singleErrorFile in lstErroredFiles)
            {
                singleErrorFile.Status = FileStatus.ERROR_TRANSFORM;
            }
            var transformedFiles = ApiData.Where(p => lstErroredFiles.Contains(p.FileEntity) == false).Select(p => p.FileEntity).ToList();
            foreach (var singleTransformedFile in transformedFiles.Distinct())
            {
                singleTransformedFile.Status = FileStatus.TRANSFORMED;
            }
            ctx.SaveChanges();
            ApiData.Clear();
        }

        private static async Task InsertBootrapData(DataFlowContext ctx)
        {
            var bootStrapPayloads =
                ctx.bootstrapdatas.Where(p => p.ProcessedDate.HasValue == false).OrderBy(p => p.ProcessingOrder).ToList();
            foreach (var singlePayload in bootStrapPayloads)
            {
                var entity = singlePayload.entity;
                var metadata = entity.Metadata;
                string endpointUrl = RetrieveEndpointUrlFromMetadata(metadata, ctx);
                string authorizeUrl = GetAuthorizeUrl(ctx);
                string accessTokenUrl = GetAccessTokenUrl(ctx);
                string clientId = GetApiClientId(ctx);
                string clientSecret = GetApiClientSecret(ctx);
                string authCode = await RetrieveAuthorizationCode(authorizeUrl, clientId: clientId);
                string accessToken = await RetrieveAccessToken(accessTokenUrl, clientId, clientSecret, authCode);
                JToken convertedPayload = JToken.Parse(singlePayload.Data);
                if (convertedPayload.Type == JTokenType.Array)
                {
                    foreach(var singleElement in (JArray)convertedPayload)
                    {
                        var dataToInsert = singleElement.ToString();
                        await PostBootstrapData(endpointUrl, accessToken, dataToInsert);
                    }
                }
                else
                {
                    await PostBootstrapData(endpointUrl, accessToken, singlePayload.Data);
                }
            }
        }

        private static async Task PostBootstrapData(string endpointUrl, string accessToken, string dataToInsert)
        {
            HttpMethod method = HttpMethod.Post;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                string strId = string.Empty;
                string strIdName = string.Empty;
                StringContent strContent = new StringContent(dataToInsert);
                strContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = null;
                response = await httpClient.PostAsync(endpointUrl, strContent);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Created:
                        break;
                    case System.Net.HttpStatusCode.OK:
                        break;
                    default:
                        string strError = await response.Content.ReadAsStringAsync();
                        break;
                }
            }
        }

        private static async Task<int> ProcessApiData(DataFlowContext ctx, List<log_ingestion> lstIngestionMessages, string accessToken, int iCurrentRecord, List<file> lstErroredFiles)
        {
            Log(log4net.Core.Level.Info, "Processing ApiData.");
            foreach (var singleApiData in ApiData)
            {
                Log(log4net.Core.Level.Info, "Inserting Data For File {0}", singleApiData.FileEntity.URL);
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
                    if (!lstErroredFiles.Contains(singleApiData.FileEntity))
                        lstErroredFiles.Add(singleApiData.FileEntity);
                    continue; // we will not process if we cannot read metadata
                }
                Log(log4net.Core.Level.Info, "Api Insertion Record: {0} of {1}", iCurrentRecord, ApiData.Count);
                Log(log4net.Core.Level.Debug, "Payload: {0}", ApiData[iCurrentRecord-1].Value);
                iCurrentRecord++;
                string endpointUrl = RetrieveEndpointUrlFromMetadata(singleApiData.Key.Metadata, ctx);
                HttpMethod method = HttpMethod.Post;
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
                        //case "studentAssessments":
                        //    break;
                        //case "studentSchoolAssociations":
                        //    break;
                        //case "studentSectionAssociations":
                        //    break;
                        //case "staffs":
                        //    break;
                        //case "assessments":
                        //    break;
                        //case "staffSchoolAssociations":
                        //    break;
                        //case "staffSectionAssociations":
                        //    break;
                        //case "schools":
                        //    break;
                        //case "localEducationAgencies":
                        //    break;
                        //case "sections":
                        //    break;
                        //case "assessmentItem":
                        //    break;
                        default:
                            break;
                    }
                    StringContent strContent = new StringContent(singleApiData.Value.ToString());
                    strContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response = null;
                    response = await httpClient.PostAsync(endpointUrl, strContent);
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            break;
                        case System.Net.HttpStatusCode.Created:
                            Log(log4net.Core.Level.Info, "Data Inserted on endpoint: {0}", endpointUrl);
                            InsertedIds.Add(new KeyValuePair<string, string>(strIdName, strId));
                            lstIngestionMessages.Add(new log_ingestion()
                            {
                                Date = DateTime.UtcNow,
                                //Filename = singleApiData.Key
                                Result = "SUCCESS",
                                Message = string.Format("Record Created:\r\nRow Number: {0}\r\nEndPoint Url: {1}\r\nAgent ID:{2}\r\nFile Name:{3}\r\nData:\r\n{4}", singleApiData.RowNumber, endpointUrl,singleApiData.FileEntity.AgentID,singleApiData.FileEntity.Filename, singleApiData.Value.ToString()),
                                Level = "INFORMATION",
                                Operation = "TransformingData",
                                Process = "transform-api-load-janitor"
                            });
                            break;
                        default:
                            string strError = await response.Content.ReadAsStringAsync();
                            Log(log4net.Core.Level.Error, "Data Error on Insert on endpoint: {0}, Row Number: {1}, Status: {2}, Error: {3}", endpointUrl, singleApiData.RowNumber, response.StatusCode, strError);
                            var singleIngestionError =
                                new log_ingestion()
                                {
                                    Date = DateTime.UtcNow,
                                    //Filename = singleApiData.Key
                                    Result = "ERROR",
                                    Message = string.Format("Message: {0}. Row Number: {1} EndPoint Url: {2}\r\nAgent ID:{3}\r\nFile Name:{4}\r\nData:\r\n{5}", strError, singleApiData.RowNumber, endpointUrl,singleApiData.FileEntity.AgentID, singleApiData.FileEntity.Filename, singleApiData.Value.ToString()),
                                    Level = "ERROR",
                                    Operation = "TransformingData",
                                    Process = "transform-api-load-janitor"
                                };
                            lstIngestionMessages.Add(singleIngestionError);
                            if (!lstErroredFiles.Contains(singleApiData.FileEntity))
                                lstErroredFiles.Add(singleApiData.FileEntity);
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
                        Log(log4net.Core.Level.Error, ex.ToString());
                    }
                }
            }

            return iCurrentRecord;
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
                    case System.Net.HttpStatusCode.NotFound:
                        result = false;
                        break;
                    default:
                        var message = await response.Content.ReadAsStringAsync();
                        break;
                }
            }
            return new KeyValuePair<bool, string>(result, recordId);
        }

        private static string GetEnvironmentVariable(string name)
        {
            string value = System.Environment.GetEnvironmentVariable(name);
            if (String.IsNullOrWhiteSpace(value))
                throw new Exception("There is no Environment Variable/Configuration Setting for " + name);
            return value;
        }

        private static string GetApiBaseUrl(DataFlowContext ctx)
        {
            return ctx.configurations.Where(p => p.Key == "API_SERVER_BASEURL").First().Value;
        }
        private static string GetAccessTokenUrl(DataFlowContext ctx)
        {
            string baseUrl = GetApiBaseUrl(ctx);
            return baseUrl + "/oauth/token";
        }

        private static string GetAuthorizeUrl(DataFlowContext ctx)
        {
            string baseUrl = GetApiBaseUrl(ctx);
            return baseUrl + "/oauth/authorize";
        }

        private static string GetApiClientSecret(DataFlowContext ctx)
        {
            return ctx.configurations.Where(p => p.Key == "API_SERVER_SECRET").First().Value;
        }

        private static string GetApiClientId(DataFlowContext ctx)
        {
            return ctx.configurations.Where(p => p.Key == "API_SERVER_KEY").First().Value;
        }

        private static string RetrieveEndpointUrlFromMetadata(string metadata, DataFlowContext ctx)
        {
            string strUrl = string.Empty;
            try
            {
                JToken swaggerMetaData = JToken.Parse(metadata);
                //string basePath = swaggerMetaData["basePath"].Value<string>();
                string basePath = GetApiBaseUrl(ctx) + "/api/v2.0/2017";
                string resourcePath = swaggerMetaData["resourcePath"].Value<string>();
                strUrl = string.Format("{0}{1}", basePath, resourcePath);
            }
            catch (Exception ex)
            {
                throw ex;
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
                Log(log4net.Core.Level.Info,
                    "Retrieving auth code from {0}", authorizeUrl);
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

        private static async Task ProcessDataMapAgent(IOrderedEnumerable<datamap_agent> dataMapAgents,
            string cloudFileUrl, file fileEntity, DataFlowContext ctx)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
    Properties.Settings.Default.StorageConnectionString);
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare fileShare = fileClient.GetShareReference(Properties.Settings.Default.FileShareName);
            CloudFile file = new CloudFile(new Uri(cloudFileUrl), storageAccount.Credentials);
            string strFileText = file.DownloadText();
            TransformFile(dataMapAgents, fileEntity, strFileText);
            await PostTransformedData(ctx);
        }

        private static void TransformFile(IOrderedEnumerable<datamap_agent> dataMapAgents, file fileEntity, string strFileText)
        {
            using (StringReader strReader = new StringReader(strFileText))
            {
                using (CsvHelper.CsvReader reader = new CsvHelper.CsvReader(strReader))
                {
                    int rowNum = 1;
                    while (reader.Read())
                    {
                        rowNum++;
                        //if (rowNum == 50)
                        //    break;
                        foreach (var singleDataMapAgent in dataMapAgents)
                        {
                            Log(log4net.Core.Level.Info, "Processing Data Map Agent: {0}. Agent: {1}. Data Map: {2}. Entity: {3}. Family: {4}. Row #: {5}",
                                singleDataMapAgent.datamap.ID, singleDataMapAgent.AgentID, singleDataMapAgent.DataMapID, singleDataMapAgent.datamap.entity.Name,
                                singleDataMapAgent.datamap.entity.Family, rowNum);
                            var entity = singleDataMapAgent.datamap.entity;
                            //if (entity.Name != "studentAssessments")
                            //    continue;
                            //if (entity.Name != "studentAssessments")
                            //if (entity.Name != "studentAssessments")
                            //    continue;
                            //if (entity.Name != "assessments")
                            //    continue;
                            //if (entity.Name != "assessmentItem")
                            //    continue;
                            //if (entity.Name == "students")
                            //    continue;
                            var dataMap = singleDataMapAgent.datamap;
                            /*try
                            {*/
                            JToken generatedRow = ProcessCSVRow(entity, dataMap, reader);
                            RemoveCustomHints(ref generatedRow, reader.FieldHeaders, reader.CurrentRecord);
                            //RemoveRequiredFields(ref generatedRow, reader.FieldHeaders, reader.CurrentRecord);
                            ApiData.Add(new ResultingMapInfo()
                            {
                                Key = entity,
                                Value = generatedRow,
                                FileEntity = fileEntity,
                                RowNumber = rowNum
                            });
                            /*}
                             catch (Exception ex)
                            {
                                Log(log4net.Core.Level.Error, "Error Processing Row: {0}. File: {1}. Message: {2}", rowNum, cloudFileUrl, ex.ToString());
                            } */
                        }
                    }
                }

            }
        }

        private static void RemoveCustomHints(ref JToken generatedRow, string[] headers, string[] currentRecord)
        {
            RemoveRequiredProperty(generatedRow, headers, currentRecord, 0);
        }

        public static void RemoveRequiredProperty(JToken token, string[] headers, string[] currentRecord, int level)
        {
            try
            {
                switch (token.Type)
                {
                    case JTokenType.Object:
                        foreach (JToken subToken in token)
                        {
                            if (subToken.Type == JTokenType.Property)
                            {
                                JProperty prop = (JProperty)subToken;
                                if (prop.Name == "studentObjectiveAssessments")  //TODO:  Right now, this is just focused on one use case, but we should abstract to ensure it works for others
                                {
                                    List<JToken> removeList = new List<JToken>();

                                    foreach (JObject subProp in prop.Value)
                                    {
                                        bool required = false;

                                        if (subProp["_required"] != null)
                                        {
                                            required = true;

                                            JArray requireds = (JArray)subProp["_required"];
                                            int found = 0;

                                            foreach (string requiredFields in subProp["_required"])
                                            {

                                                int pos = Array.IndexOf(headers, requiredFields);
                                                if (pos > 0 && currentRecord[pos].Length > 0)
                                                {
                                                    { found++; } // if this field is found to have data, increment the count
                                                }
                                            }

                                            if (found != requireds.Count)
                                            {
                                                removeList.Add(subProp);
                                            }
                                        }

                                        if (required) { 
                                            subProp.Property("_required").Remove();
                                        }
                                    }

                                    foreach (JToken node in removeList)
                                    {
                                        node.Remove();
                                    }

                                


                                }
                            }
                            RemoveRequiredProperty(subToken, headers, currentRecord, level+1);
                        }

                        break;
                    case JTokenType.Array:
                        foreach (JToken subToken in token)
                        {
                            RemoveRequiredProperty(subToken, headers, currentRecord, level+1);
                        }
                        break;
                    case JTokenType.Property:
                        break;
                    default:
                        Log(log4net.Core.Level.Info, "Token type: {0}", token.Type);
                        break;
                }
            }
            catch (Exception ex)
            {
                _log.Error("Error in RemoveRequiredProperty: ", ex);
                //Log(log4net.Core.Level.Error, "Error in RemoveRequiredProperty: ", ex);
            }


            /*
            //Check https://stackoverflow.com/questions/40116088/remove-fields-form-jobject-dynamically-using-json-net
            if (token.Type == JTokenType.Object)
            {
                foreach (JProperty prop in token.Children<JProperty>().ToList())
                {
                    bool removed = false;
                    if (prop.Name == properyToRemove)
                    {
                        prop.Remove();
                        removed = true;
                        break;
                    }
                    if (!removed)
                    {
                        RemoveSensitiveProperties(prop.Value, properyToRemove, headers, currentRecord);
                    }
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (JToken subToken in token)
                {
                    RemoveSensitiveProperties(subToken, properyToRemove, headers, currentRecord);
                }
                if (token.Children().Count() == 0)
                {
                    token.Remove();
                    token.Parent.Remove();
                }
                foreach (JToken child in token.Children())
                {
                    RemoveSensitiveProperties(child, properyToRemove, headers, currentRecord);
                }
                
            }
        */
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
            Log(log4net.Core.Level.Error, "An unhandled exception has occurred: " + ((Exception)e.ExceptionObject).ToString());
        }

        private static void TransformCSVRow(JToken originalMap, ref JToken outputData, CsvReader reader,
            JArray originalArray = null, bool? hasArrayElementBeingProcessed = null, string arrayItemName = null, int? arrayPos = null)
        {
            if (originalMap.Type == JTokenType.Array)
            {
                JArray jArray = (JArray)(originalMap);
                int iPos = 0;
                foreach (var singleItem in jArray)
                {
                    TransformCSVRow(singleItem, ref outputData, reader, originalArray: jArray, hasArrayElementBeingProcessed: hasArrayElementBeingProcessed, arrayItemName: originalMap.Path, arrayPos: iPos);
                    iPos++;
                }
            }
            var jChildrenProperties = originalMap.Children<JProperty>();
            string[] mappinHints = { "data-type", "source", "source-column", "source-table", "value" };
            bool hasMappingHints = jChildrenProperties.Any(p => mappinHints.Contains(p.Name));
            if (hasMappingHints)
            {
                bool wasValueSet = false;
                var dataTypeField = jChildrenProperties.Where(p => p.Name == "data-type").FirstOrDefault();
                var sourceField = jChildrenProperties.Where(p => p.Name == "source").FirstOrDefault();
                var sourceTable = jChildrenProperties.Where(p => p.Name == "source-table").FirstOrDefault();
                var sourceColumnField = jChildrenProperties.Where(p => p.Name == "source-column").FirstOrDefault();
                var valueField = jChildrenProperties.Where(p => p.Name == "value").FirstOrDefault();
                var defaultValueField = jChildrenProperties.Where(p => p.Name == "default").FirstOrDefault();
                if (sourceField != null)
                {
                    JToken initialOutputData = null;
                    string[] splittedPath = null;
                    splittedPath = originalMap.Path.Split('.');
                    SetInitialOutputData(originalMap, outputData, originalArray, ref hasArrayElementBeingProcessed, ref arrayItemName, ref initialOutputData, splittedPath);
                    SetFieldValue(originalMap, outputData, reader, originalArray, ref hasArrayElementBeingProcessed, ref wasValueSet, dataTypeField, sourceField, sourceTable, sourceColumnField, valueField, defaultValueField, initialOutputData, splittedPath);
                    bool hasRequiredHint = jChildrenProperties.Any(p => p.Name == "_required");
                    if (!wasValueSet)
                    {
                        if (hasRequiredHint)
                        {
                            List<string> lstMissingColumnsInCSV = new List<string>();
                            var requiredTokens = jChildrenProperties.Where(p => p.Name == "_required").FirstOrDefault();
                            foreach (var singleTokenChild in requiredTokens.Children())
                            {
                                foreach (var subSingleTokenChild in singleTokenChild.Children())
                                {
                                    string strColumnName = subSingleTokenChild.ToString();
                                    string fieldValue = string.Empty;
                                    if (!reader.TryGetField(strColumnName, out fieldValue))
                                        lstMissingColumnsInCSV.Add(strColumnName);
                                }
                            }
                            if (lstMissingColumnsInCSV.Count > 0)
                            {
                                throw new Exception(string.Format("Missing columns in source file: {0}", string.Join(",", lstMissingColumnsInCSV)));
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var jSingleProperty in jChildrenProperties)
                {
                    foreach (var jSingleChild in jSingleProperty.Children())
                    {
                        TransformCSVRow(jSingleChild, ref outputData, reader, originalArray: originalArray, hasArrayElementBeingProcessed: hasArrayElementBeingProcessed, arrayItemName: arrayItemName, arrayPos: arrayPos);
                    }
                }
            }
        }

        private static void SetInitialOutputData(JToken originalMap, JToken outputData, JArray originalArray, ref bool? hasArrayElementBeingProcessed, ref string arrayItemName, ref JToken initialOutputData, string[] splittedPath)
        {
            if (splittedPath.Length > 0)
            {
                try
                {
                    if (originalArray != null && hasArrayElementBeingProcessed.GetValueOrDefault() == false)
                    {
                        string path = string.Format("{0}", originalMap.Path);
                        var t = outputData.SelectToken(path);
                        if (t == null)
                        {
                            int iFirstDotPos = arrayItemName.IndexOf(".");
                            if (iFirstDotPos >= 0)
                            {
                                arrayItemName = arrayItemName.Remove(0, iFirstDotPos + 1);
                                path = string.Format("{0}{1}", arrayItemName, originalMap.Path);
                                t = outputData.SelectToken(path);
                            }
                        }
                        try
                        {
                            initialOutputData = t.Parent;
                        }
                        catch (Exception exf)
                        {

                        }
                        hasArrayElementBeingProcessed = true;
                    }
                    else
                    {
                        initialOutputData = RetrieveValueBySplittingPath(outputData, splittedPath);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static void SetFieldValue(JToken originalMap, JToken outputData, CsvReader reader, 
            JArray originalArray, ref bool? hasArrayElementBeingProcessed, ref bool wasValueSet, 
            JProperty dataTypeField, JProperty sourceField, JProperty sourceTable, JProperty sourceColumnField, 
            JProperty valueField, JProperty defaultValueField, JToken initialOutputData, string[] splittedPath)
        {
            switch (sourceField.Value.ToString())
            {
                case "column":
                    string csvColumnName = sourceColumnField.Value.ToString();
                    string csvValue = reader[csvColumnName];
                    if (originalArray != null && hasArrayElementBeingProcessed.GetValueOrDefault() == false)
                    {
                        JProperty parentProperty = (JProperty)originalMap.Parent;
                        JProperty prop = (JProperty)initialOutputData;
                        prop.Value = ConvertDataType(dataTypeField, csvValue, defaultValueField, ref wasValueSet);
                        if (!wasValueSet)
                            prop.Remove();
                        hasArrayElementBeingProcessed = true;
                    }
                    else
                    {
                        if (splittedPath.Length > 0)
                        {
                            if (initialOutputData.Type == JTokenType.Property)
                            {
                                JProperty prop = (JProperty)initialOutputData;
                                prop.Value = ConvertDataType(dataTypeField, csvValue, defaultValueField, ref wasValueSet);
                                if (!wasValueSet)
                                {
                                    initialOutputData.Parent.Remove();
                                }
                            }
                            else
                            {
                                initialOutputData[splittedPath[splittedPath.Length - 1]] = ConvertDataType(dataTypeField, csvValue, defaultValueField, ref wasValueSet);
                                /*
                                if (!wasValueSet)
                                    initialOutputData[splittedPath[splittedPath.Length - 1]].Remove();
                                */
                            }
                        }
                        else
                        {
                            outputData[originalMap.Parent.Path] = ConvertDataType(dataTypeField, csvValue, defaultValueField, ref wasValueSet);
                            if (!wasValueSet)
                                outputData[originalMap.Parent.Path].Remove();
                        }
                    }
                    break;
                case "lookup_table":
                case "lookup-table":
                    if (originalArray != null && hasArrayElementBeingProcessed.GetValueOrDefault() == false)
                    {
                        JProperty prop = (JProperty)JProperty.FromObject(initialOutputData);
                        prop.Value = ConvertDataType(dataTypeField,
                                GetValueFromLookupTable(sourceTable.Value.ToString(), sourceColumnField.Value.ToString(), reader), defaultValueField, ref wasValueSet);
                        if (!wasValueSet)
                            prop.Remove();
                        hasArrayElementBeingProcessed = true;
                    }
                    else
                    {
                        if (splittedPath.Length > 0)
                        {
                            if (initialOutputData.Type == JTokenType.Property)
                            {
                                JProperty prop = (JProperty)initialOutputData;
                                prop.Value = ConvertDataType(dataTypeField,
                                    GetValueFromLookupTable(sourceTable.Value.ToString(), sourceColumnField.Value.ToString(), reader), defaultValueField, ref wasValueSet);
                                if (!wasValueSet)
                                    prop.Remove();
                            }
                            else
                            {
                                initialOutputData[splittedPath[splittedPath.Length - 1]] =
                                    ConvertDataType(dataTypeField,
                                    GetValueFromLookupTable(sourceTable.Value.ToString(), sourceColumnField.Value.ToString(), reader), defaultValueField, ref wasValueSet);
                                if (!wasValueSet)
                                    initialOutputData[splittedPath[splittedPath.Length - 1]].Remove();
                            }
                        }
                        else
                        {
                            outputData[originalMap.Parent.Path] =
                                ConvertDataType(dataTypeField,
                                GetValueFromLookupTable(sourceTable.Value.ToString(), sourceColumnField.Value.ToString(), reader), defaultValueField, ref wasValueSet);
                            if (!wasValueSet)
                                outputData[originalMap.Parent.Path].Remove();
                        }
                    }
                    break;
                case "static":
                    if (originalArray != null && hasArrayElementBeingProcessed.GetValueOrDefault() == false)
                    {
                        JProperty prop = (JProperty)JProperty.FromObject(initialOutputData);
                        prop.Value = ConvertDataType(dataTypeField, valueField.Value.ToString(), defaultValueField, ref wasValueSet);
                        hasArrayElementBeingProcessed = true;
                        if (!wasValueSet)
                            prop.Remove();
                    }
                    else
                    {
                        if (initialOutputData != null)
                        {
                            if (splittedPath.Length > 0)
                            {
                                if (initialOutputData.Type == JTokenType.Property)
                                {
                                    JProperty prop = (JProperty)initialOutputData;
                                    prop.Value = ConvertDataType(dataTypeField, valueField.Value.ToString(), defaultValueField, ref wasValueSet);
                                    if (!wasValueSet)
                                        prop.Remove();
                                }
                                else
                                {
                                    initialOutputData[splittedPath[splittedPath.Length - 1]] =
                                        ConvertDataType(dataTypeField, valueField.Value.ToString(), defaultValueField, ref wasValueSet);
                                    if (!wasValueSet)
                                        initialOutputData[splittedPath[splittedPath.Length - 1]].Remove();
                                }
                            }
                            else
                            {
                                outputData[originalMap.Parent.Path] =
                                    ConvertDataType(dataTypeField, valueField.Value.ToString(), defaultValueField, ref wasValueSet);
                                if (!wasValueSet)
                                    outputData[originalMap.Parent.Path].Remove();
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private static JToken ConvertDataType(JProperty dataTypeField, string csvValue, 
            JProperty defaultValueField, ref bool wasValueSet)
        {
            object result = null;
            if (dataTypeField != null)
            {
                switch (dataTypeField.Value.ToString())
                {
                    case "string":
                        result = csvValue;
                        break;
                    case "integer":
                        if (!string.IsNullOrWhiteSpace(csvValue))
                            result = Convert.ToInt32(csvValue);
                        else
                            result = 0;
                        break;
                    case "date-time":
                        result = csvValue;
                        break;
                    case "boolean":
                        try
                        {
                            result = Convert.ToBoolean(csvValue);
                        }
                        catch (Exception bConvEx)
                        {
                            result = csvValue;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
                result = csvValue;
            wasValueSet = true;
            if (
                (result == null ||
                (result != null && String.IsNullOrWhiteSpace(result.ToString()))) &&
                defaultValueField != null)
            {
                result = defaultValueField.Value.ToString();
            }
            else
            {
                //if we found no mapping we will set the value to an empty string
                if (result == null)
                    result = string.Empty;
            }
            if (String.IsNullOrWhiteSpace(result.ToString()))
            {
                wasValueSet = false;
            }
            return JToken.FromObject(result);
        }

        private static JToken RetrieveValueBySplittingPath(JToken outputData, string[] splittedPath)
        {
            var initialOutputData = outputData;
            for (int i = 0; i < splittedPath.Length; i++)
            {
                if (i < splittedPath.Length - 1)
                    initialOutputData = initialOutputData[splittedPath[i]];
            }

            return initialOutputData;
        }

        private static string GetValueFromLookupTable(string lookupTable, string lookupColumn, CsvReader csvRow)
        {
            string result = string.Empty;
            string valueInCSV = csvRow[lookupColumn];
            var matchingRecord = MappingLookups.Where(p => p.GroupSet == lookupTable && p.Key.Trim() == valueInCSV).FirstOrDefault();
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
                        Log(log4net.Core.Level.Info, "Start of Data for Row: {0}", rowNumber);
                        for (int iCol = 0; iCol < csvReader.CurrentRecord.Length; iCol++)
                        {
                            string columnName = csvReader.FieldHeaders[iCol];
                            string columnValue = csvReader.GetField(iCol);
                            Log(log4net.Core.Level.Info, "{0} = {1}", columnName, columnValue);
                        }
                        Log(log4net.Core.Level.Info, "End of Data for Row: {0}", rowNumber);
                        rowNumber++;
                    }
                }
            }
        }

        private static void TransformFilesFromAzureFileStorage()
        {
            // Check https://docs.microsoft.com/en-us/azure/storage/files/storage-dotnet-how-to-use-files
            // Parse the connection string and return a reference to the storage account.
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
                Log(log4net.Core.Level.Info, singleDirectory.Uri.ToString());
                var currentDirectoryFiles = singleDirectory.ListFilesAndDirectories().OfType<CloudFile>();
                foreach (var singleFile in currentDirectoryFiles)
                {
                    var extension = Path.GetExtension(singleFile.Name).ToUpper();
                    if (extension != ".CSV")
                        continue;
                    Log(log4net.Core.Level.Info, singleFile.Uri.ToString());
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
                        Log(log4net.Core.Level.Error, ex.ToString());
                    }
                }
            }
            foreach (CloudFile singleFile in allRootFiles)
            {
                Log(log4net.Core.Level.Info, singleFile.Uri.ToString());
                using (var strReader = singleFile.OpenRead())
                {
                    string strFileContent = singleFile.DownloadText();
                    Log(log4net.Core.Level.Info, "**********START OF {0}**********", singleFile.Name);
                    Log(log4net.Core.Level.Info, strFileContent);
                    Log(log4net.Core.Level.Info, "**********END OF {0}**********", singleFile.Name);
                    strReader.Close();
                }
            }
        }

        private static void Log(log4net.Core.Level level, string message, params object[] args)
        {
            string messageToLog = string.Empty;
            try
            {
                if (args != null && args.Count() > 0)
                {
                    messageToLog = string.Format(message, args);
                }

                if (level.Value == log4net.Core.Level.Error.Value)
                    _log.Error(messageToLog);
                else if (level.Value == log4net.Core.Level.Info.Value)
                    _log.Info(messageToLog);
                else
                    _log.Debug(messageToLog);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error logging: " + ex.ToString());
            }
        }
    }

    public class ResultingMapInfo
    {
        public file FileEntity { get; set; }
        public entity Key { get; set; }
        public int RowNumber { get; set; }
        public JToken Value { get; set; }
    }
}
