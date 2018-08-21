using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using CsvHelper;
using System.Net;
using System.Net.Http;
using NLog;
using System.Configuration;
using System.Diagnostics;
using DataFlow.Common.DAL;
using System.Data.Entity;
using DataFlow.Models;
using DataFlow.Common.Enums;
using DataFlow.Server.TransformLoad.Interfaces;
using DataFlow.Server.TransformLoad.Implements;


namespace DataFlow.Server.TransformLoad
{
    internal class Program
    {
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();
        private static List<DataMap> DataMapsList { get; set; } = null;
        private static List<Lookup> MappingLookups { get; set; } = null;

        private static string _accessToken = null;
        private static int numberOfSimultaneousTasks = GetNumberOfSimultaneousTasks();
        private static ParallelOptions parallelOptions = null;

        private static Dictionary<int, ProcessCounter> _processCounter = new Dictionary<int, ProcessCounter>();

        #region Parallel/Multi-Threading variables
        private static Object ApiDataLock = new Object();
        private static List<KeyValuePair<string, string>> InsertedIds { get; set; } = new List<KeyValuePair<string, string>>();
        private static List<Action> lstRowsTransformingActions = new List<Action>();
        private static List<Action> lstRowsToPostActions = new List<Action>();
        private static Object lstRowsToPostActionsLock = new Object();
        private static List<ResultingMapInfo> ApiData = new List<ResultingMapInfo>();
        private static Object ProcessedDataLock = new Object();
        private static Dictionary<string, ResultingMapInfo> ProcessedData = new Dictionary<string, ResultingMapInfo>();
        #endregion Parallel/Multi-Threading variables
        public static void Main(string[] args)
        {
            // Force TLS 1.2 as per Ed-Fi ODS-2403 -- https://tracker.ed-fi.org/browse/ODS-2403
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                parallelOptions = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = GetNumberOfSimultaneousTasks(),
                    TaskScheduler = TaskScheduler.Default
                };
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                await StartProcessing();
                watch.Stop();

                _log.Info("Time Elapsed: {0}", watch.Elapsed.ToString());
                _log.Info("Press any key to continue");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Process Exception: " + ex.ToString());
                _log.Error(ex, "AggregateException Exception");
                foreach (var singleInnerException in ex.InnerExceptions)
                {
                    _log.Error(singleInnerException);
                }
            }
            finally
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadLine();
                }
            }
        }

        private static string GetDataFlowConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        }

        private static async Task StartProcessing()
        {
            using (DataFlowDbContext ctx = new DataFlowDbContext())
            {
                await InsertBootrapData(ctx);
                MappingLookups = ctx.Lookups.ToList();

                List<Models.File> files = ctx.Files.Where(file => file.Status.ToUpper() == FileStatusEnum.UPLOADED || file.Status.ToUpper() == FileStatusEnum.RETRY).Include(file => file.Agent).Include(file => file.Agent.DataMapAgents).Include(file => file.Agent.DataMapAgents.Select(da => da.DataMap)).Include(file => file.Agent.DataMapAgents.Select(da => da.DataMap.Entity)).ToList();

                foreach (Models.File singleFile in files)
                {
                    _log.Info("Processing file: {0}. URL: {1}", singleFile.FileName, singleFile.Url);
                    try
                    {
                        singleFile.Status = FileStatusEnum.TRANSFORMING;
                        singleFile.UpdateDate = DateTime.Now;
                        ctx.SaveChanges();
                        IFile file = GenerateIFile(singleFile);
                        await ProcessDataMapAgent(singleFile.Agent.DataMapAgents, file: file, fileEntity: singleFile, ctx: ctx);
                    }
                    catch (AggregateException aggrEx)
                    {
                        _log.Error(aggrEx, "Error awaiting ProcessDataMapAgent");
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex, "Error processing file: {0}", singleFile.Url);
                    }

                    _log.Info("Finished Processing file: {0}. URL: {1}", singleFile.FileName, singleFile.Url);
                }
            }
        }

        private static IFile GenerateIFile(Models.File singleFile)
        {
            string strFileMode = ConfigurationManager.AppSettings["FileMode"];
            ProcessingFileModeEnum fileMode = (ProcessingFileModeEnum)Enum.Parse(typeof(ProcessingFileModeEnum), strFileMode);
            IFile iFile = null;
            switch (fileMode)
            {
                case ProcessingFileModeEnum.Azure:
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["storageConnection"].ConnectionString);
                    CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
                    CloudFile file = new CloudFile(new Uri(singleFile.Url), storageAccount.Credentials);
                    iFile = new AzureCloudFile(file);
                    break;
                case ProcessingFileModeEnum.Local:
                    string localPath = new Uri(singleFile.Url).LocalPath;
                    iFile = new LocalFile(new FileInfo(localPath), singleFile.Url);
                    break;
            }
            return iFile;
        }

        private static async Task PostTransformedData(DataFlowDbContext ctx)
        {
            string authorizeUrl = GetAuthorizeUrl(ctx);
            string accessTokenUrl = GetAccessTokenUrl(ctx);
            string clientId = GetApiClientId(ctx);
            string clientSecret = GetApiClientSecret(ctx);
            string authCode = await RetrieveAuthorizationCode(authorizeUrl, clientId: clientId);
            string accessToken = await RetrieveAccessToken(accessTokenUrl, clientId, clientSecret, authCode);
            _log.Info("Start of Api Insertion: {0} records", ApiData.Count);
            await ProcessApiData(ctx, accessToken);

            System.Threading.Thread.Sleep(20000);  //TODO - The await call has other business to finish, double check and ensure everything is finished before saving status
            foreach (var singleErrorFile in lstErroredFiles)
            {
                singleErrorFile.Status = FileStatusEnum.ERROR_TRANSFORM;
                singleErrorFile.Message = String.Format("File has {0} rows, API calls processed:  Success: {1}, Exists: {2}, Error: {3}", singleErrorFile.Rows, _processCounter[singleErrorFile.Id].Success, _processCounter[singleErrorFile.Id].Exists, _processCounter[singleErrorFile.Id].Error);
                singleErrorFile.UpdateDate = DateTime.Now;
            }
            var transformedFiles = ApiData.Where(p => lstErroredFiles.Contains(p.FileEntity) == false).Select(p => p.FileEntity).ToList();
            foreach (var singleTransformedFile in transformedFiles.Distinct())
            {
                singleTransformedFile.Status = FileStatusEnum.LOADED;
                singleTransformedFile.Message = String.Format("File has {0} rows, API calls processed:  Success: {1}, Exists: {2}, Error: {3}", singleTransformedFile.Rows, _processCounter[singleTransformedFile.Id].Success, _processCounter[singleTransformedFile.Id].Exists, _processCounter[singleTransformedFile.Id].Error);
                singleTransformedFile.UpdateDate = DateTime.Now;
            }
            ctx.SaveChanges();
        }

        internal static async Task InsertBootrapData(DataFlowDbContext ctx)
        {
            var bootStrapPayloads =
                ctx.BootstrapData.Include(e => e.Entity).Where(p => p.ProcessedDate.HasValue == false || (p.UpdateDate.HasValue && p.UpdateDate > p.ProcessedDate)).OrderBy(p => p.ProcessingOrder).ToList();
            foreach (var singlePayload in bootStrapPayloads)
            {
                _log.Info("Inserting bootstrap data for ID: {0}", singlePayload.Id);
                var entity = singlePayload.Entity;
                var metadata = entity.Metadata;
                string endpointUrl = RetrieveEndpointUrlFromMetadata(metadata, ctx);
                string authorizeUrl = GetAuthorizeUrl(ctx);
                string accessTokenUrl = GetAccessTokenUrl(ctx);
                string clientId = GetApiClientId(ctx);
                string clientSecret = GetApiClientSecret(ctx);
                string authCode = await RetrieveAuthorizationCode(authorizeUrl, clientId: clientId);
                string accessToken = await RetrieveAccessToken(accessTokenUrl, clientId, clientSecret, authCode);
                JToken convertedPayload = JToken.Parse(singlePayload.Data);

                if (convertedPayload.Type == JTokenType.Array) // If there are multiple payloads as part of an array, post each payload
                {
                    foreach (var singleElement in (JArray)convertedPayload)
                    {
                        var dataToInsert = singleElement.ToString();
                        await PostBootstrapData(endpointUrl, accessToken, dataToInsert);
                    }
                }
                else // Otherwise, post the single payload
                {
                    await PostBootstrapData(endpointUrl, accessToken, singlePayload.Data);
                }

                // After updating the payload, stamp it so it doesn't run again in next cycle (unless it has been updated)
                singlePayload.ProcessedDate = DateTime.Now;
                ctx.SaveChanges();
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

        private static async Task ProcessApiData(DataFlowDbContext ctx, string accessToken)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            _log.Info("Processing ApiData.");
            var sortedAndGroupApiData = ApiData.OrderBy(x => x.ProcessingOrder).GroupBy(p => p.Key.Name);
            int fileTotalRecords = ApiData.Count();
            foreach (var singleApiDataEntity in sortedAndGroupApiData)
            {
                foreach (var singleApiData in singleApiDataEntity)
                {
                    Action taskPostSingleApiData =
                        CreatePostSingleApiDataAction(accessToken, singleApiData, fileTotalRecords);
                    lock (lstRowsToPostActionsLock)
                    {
                        lstRowsToPostActions.Add(taskPostSingleApiData);
                        if (lstRowsToPostActions.Count == numberOfSimultaneousTasks)
                        {
                            Parallel.Invoke(parallelOptions, lstRowsToPostActions.ToArray());
                            lstRowsToPostActions.Clear();
                        }
                    }
                }
                lock (lstRowsToPostActionsLock)
                {
                    if (lstRowsToPostActions.Count > 0)
                    {
                        Parallel.Invoke(parallelOptions, lstRowsToPostActions.ToArray());
                        lstRowsToPostActions.Clear();
                    }
                }
            }
            watch.Stop();
            var elapsed = watch.Elapsed;
            await Task.Yield();

        }

        private static Object lstIngestionMessagesLock = new Object();
        private static Object lstErroredFilesLock = new Object();
        private static List<LogIngestion> lstIngestionMessages = new List<LogIngestion>();
        private static List<Models.File> lstErroredFiles = new List<Models.File>();
        private static Action CreatePostSingleApiDataAction(
            string accessToken, ResultingMapInfo singleApiData, int fileTotalRecords)
        {
            Action taskPostSingleApiData = new Action(async () =>
            {
                try
                {
                    using (DataFlowDbContext ctx = new DataFlowDbContext())
                    {
                        _log.Info("Inserting Data For File {0}", singleApiData.FileEntity.Url);
                        if (String.IsNullOrWhiteSpace(singleApiData.Key.Metadata))
                        {
                            lock (lstIngestionMessagesLock)
                            {
                                ctx.LogIngestions.Add(new LogIngestion()
                                {
                                    Date = DateTime.Now,
                                    //Filename = singleApiData.Key
                                    Result = "ERROR",
                                    Message = string.Format("Entity has no Metadata. Entity ID: {0}", singleApiData.Key.Id),
                                    Level = "ERROR",
                                    Operation = "TransformingData",
                                    Process = "transform-api-load-janitor",
                                    FileName = singleApiData.FileEntity.FileName
                                });
                                ctx.SaveChanges();
                            }
                            lock (lstErroredFilesLock)
                            {
                                if (!lstErroredFiles.Contains(singleApiData.FileEntity))
                                    lstErroredFiles.Add(singleApiData.FileEntity);
                            }
                            throw new Exception("Cannot read metadata for Ed-Fi API endpoints, please run Configuration in the Admin Panel to update.");  // we will not process if we cannot read metadata
                        }
                        string endpointUrl = RetrieveEndpointUrlFromMetadata(singleApiData.Key.Metadata, ctx);
                        if (!IsNewOrModified(singleApiData, endpointUrl))
                            return;
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
                                default:
                                    break;
                            }
                            StringContent strContent = new StringContent(singleApiData.Value.ToString());
                            strContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                            HttpResponseMessage response = null;
                            try
                            {
                                response = await httpClient.PostAsync(endpointUrl, strContent);
                            }
                            catch (AggregateException aggrEx)
                            {
                                _log.Error(aggrEx, "Error invoking httpClient.PostAsync.");
                            }
                            catch (Exception ex)
                            {
                                _log.Info(ex, "Error invoking httpClient.PostAsync.");
                            }
                            //TODO: Research why response was null, which exception happened?
                            if (response != null)
                                await ProcessResponse(singleApiData, endpointUrl, strId, strIdName, response, fileTotalRecords);
                            else
                                _log.Info("WARNING!!! response = await httpClient.PostAsync(endpointUrl, strContent) returned null or an exception happened");
                        }
                        lock (lstIngestionMessagesLock)
                        {
                            if (lstIngestionMessages.Count > 0)
                            {
                                try
                                {
                                    lstIngestionMessages.ForEach((singleIngestionError) =>
                                    {
                                        ctx.LogIngestions.Add(singleIngestionError);
                                    });
                                    ctx.SaveChanges();
                                    lstIngestionMessages.Clear();
                                }
                                catch (Exception ex)
                                {
                                    _log.Error(ex, "Unexpected error in CreatePostSingleApiDataAction()");
                                }
                            }
                        }
                    }
                }
                catch (AggregateException aggrEx)
                {
                    _log.Error(aggrEx, "Error on method for posting single Api Data.");
                }
                catch (Exception ex)
                {
                    _log.Error(ex, "Error on method for posting single Api Data.");
                }
            });
            return taskPostSingleApiData;
        }

        private static async Task ProcessResponse(ResultingMapInfo singleApiData, string endpointUrl, string strId, 
            string strIdName, HttpResponseMessage response, int fileTotalRecords)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    _log.Info("Data Exists on endpoint: {0}", endpointUrl);
                    lock (lstIngestionMessagesLock)
                    {
                        lstIngestionMessages.Add(new LogIngestion()
                        {
                            Date = DateTime.Now,
                            //Filename = singleApiData.Key
                            Result = "SUCCESS",
                            Message = string.Format("Record Exists:\r\nRow Number: {0}\r\nEndPoint Url: {1}\r\nData:\r\n{2}", singleApiData.RowNumber, endpointUrl, singleApiData.Value.ToString()),
                            Level = "INFORMATION",
                            Operation = "TransformingData",
                            Process = "transform-api-load-janitor",
                            FileName = singleApiData.FileEntity.FileName,
                            AgentId  = singleApiData.FileEntity.AgentId,
                            RecordCount = fileTotalRecords
                        });
                        _processCounter[singleApiData.FileEntity.Id].Exists++;
                    }
                    break;
                case System.Net.HttpStatusCode.Created:
                    _log.Info("Data Inserted on endpoint: {0}", endpointUrl);
                    lock (lstIngestionMessagesLock)
                    {
                        InsertedIds.Add(new KeyValuePair<string, string>(strIdName, strId));
                        lstIngestionMessages.Add(new LogIngestion()
                        {
                            Date = DateTime.Now,
                            //Filename = singleApiData.Key
                            Result = "SUCCESS",
                            Message = string.Format("Record Created:\r\nRow Number: {0}\r\nEndPoint Url: {1}\r\nAgent ID:{2}\r\nFile Name:{3}\r\nData:\r\n{4}", singleApiData.RowNumber, endpointUrl, singleApiData.FileEntity.AgentId, singleApiData.FileEntity.FileName, singleApiData.Value.ToString()),
                            Level = "INFORMATION",
                            Operation = "TransformingData",
                            Process = "transform-api-load-janitor",
                            FileName = singleApiData.FileEntity.FileName,
                            AgentId = singleApiData.FileEntity.AgentId,
                            RecordCount = fileTotalRecords
                        });
                        _processCounter[singleApiData.FileEntity.Id].Success++;
                    }
                    break;
                default:
                    string strError = await response.Content.ReadAsStringAsync();
                    _log.Info("Data Error on Insert on endpoint: {0}, Row Number: {1}, Status: {2}, Error: {3}", endpointUrl, singleApiData.RowNumber, response.StatusCode, strError);
                    lock (lstIngestionMessagesLock)
                    {
                        var singleIngestionError =
                            new LogIngestion()
                            {
                                Date = DateTime.Now,
                                //Filename = singleApiData.Key
                                Result = "ERROR",
                                Message = string.Format("Message: {0}. Row Number: {1} EndPoint Url: {2}\r\nAgent ID:{3}\r\nFile Name:{4}\r\nData:\r\n{5}", strError, singleApiData.RowNumber, endpointUrl, singleApiData.FileEntity.AgentId, singleApiData.FileEntity.FileName, singleApiData.Value.ToString()),
                                Level = "ERROR",
                                Operation = "TransformingData",
                                Process = "transform-api-load-janitor",
                                FileName = singleApiData.FileEntity.FileName,
                                AgentId = singleApiData.FileEntity.AgentId,
                                RecordCount = fileTotalRecords
                            };
                        lstIngestionMessages.Add(singleIngestionError);
                        _processCounter[singleApiData.FileEntity.Id].Error++;
                    }
                    break;
            }
        }

        private static bool IsNewOrModified(ResultingMapInfo singleApiData, string endPoint)
        {
            bool isNewOrModified = false;
            lock (ProcessedDataLock)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine("Endpoint: " + endPoint);
                strBuilder.AppendLine(singleApiData.Value.ToString());

                using (var md5Algorithm = System.Security.Cryptography.MD5.Create())
                {
                    byte[] utf32Bytes = Encoding.UTF32.GetBytes(strBuilder.ToString());
                    var computedHash = md5Algorithm.ComputeHash(utf32Bytes);
                    var base64ResultingHash = Convert.ToBase64String(computedHash);
                    var dbMatchingEntityQuery = ProcessedData.Where(p => p.Key == base64ResultingHash);
                    if (dbMatchingEntityQuery.Count() == 0)
                    {
                        ProcessedData.Add(base64ResultingHash, singleApiData);
                        isNewOrModified = true;
                    }
                    else
                        isNewOrModified = false;
                }
            }
            return isNewOrModified;
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

        private static string GetApiUrl(DataFlowDbContext ctx)
        {
            return ctx.Configurations.Where(p => p.Key == "API_SERVER_URL").First().Value;
        }
        internal static string GetAccessTokenUrl(DataFlowDbContext ctx)
        {
            string url = GetApiUrl(ctx);
            url = DataFlow.Common.Helpers.UrlUtility.GetUntilOrEmpty(url, "/api");
            return url + "/oauth/token";
        }

        internal static string GetAuthorizeUrl(DataFlowDbContext ctx)
        {
            string url = GetApiUrl(ctx);
            url = DataFlow.Common.Helpers.UrlUtility.GetUntilOrEmpty(url, "/api");
            return url + "/oauth/authorize";
        }

        internal static string GetApiClientSecret(DataFlowDbContext ctx)
        {
            return ctx.Configurations.Where(p => p.Key == "API_SERVER_SECRET").First().Value;
        }

        internal static string GetApiClientId(DataFlowDbContext ctx)
        {
            return ctx.Configurations.Where(p => p.Key == "API_SERVER_KEY").First().Value;
        }

        private static string RetrieveEndpointUrlFromMetadata(string metadata, DataFlowDbContext ctx)
        {
            string strUrl = string.Empty;
            try
            {
                JToken swaggerMetaData = JToken.Parse(metadata);
                string urlPath = GetApiUrl(ctx);
                string resourcePath = swaggerMetaData["resourcePath"].Value<string>();
                strUrl = string.Format("{0}{1}", urlPath, resourcePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strUrl;
        }

        internal static async Task<string> RetrieveAccessToken(string accessTokenUrl, string clientId, string clientSecret, string authCode)
        {
            if (_accessToken == null)
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
                            _accessToken = jsonToken["access_token"].ToString();
                            /*
                             * Check https://techdocs.ed-fi.org/display/ODSAPI23/Authentication
                             * Most platform hosts issue an access token that expires on a 30 minute sliding expiration. The sliding expiration window is extended on every operation with the API.
                            */
                            //string _tokenExpiresIn = jsonToken["expires_in"].ToString();
                            break;
                        default:
                            break;
                    }
                }
            }

            return _accessToken;
        }

        internal static async Task<string> RetrieveAuthorizationCode(string authorizeUrl, string clientId)
        {
            string code = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                List<KeyValuePair<string, string>> lstParameters = new List<KeyValuePair<string, string>>();
                lstParameters.Add(new KeyValuePair<string, string>("Client_id", clientId));
                lstParameters.Add(new KeyValuePair<string, string>("Response_type", "code"));
                FormUrlEncodedContent contentParams = new FormUrlEncodedContent(lstParameters);
                _log.Info("Retrieving auth code from {0}", authorizeUrl);
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

        private static async Task ProcessDataMapAgent(ICollection<DataMapAgent> dataMapAgents, IFile file, Models.File fileEntity, DataFlowDbContext ctx)
        {
            string[] excelFileTypes = { "XLS", "XLSX" };
            bool isExcelFile = excelFileTypes.Contains(Path.GetExtension(file.Name).ToUpper());
            if (isExcelFile)
            {
                string tempPath = System.IO.Path.GetTempPath();
                string tempFileFullPath = Path.Combine(tempPath, file.Name);
                if (file is AzureCloudFile)
                    file.DownloadToFile(tempFileFullPath, FileMode.Create);
                TransformExcelFile(dataMapAgents, fileEntity, tempFileFullPath);
            }
            else
            {
                string strFileText = file.DownloadText();
                TransformFile(dataMapAgents, fileEntity, strFileText);
            }
            try
            {
                fileEntity.Status = FileStatusEnum.LOADING;
                fileEntity.UpdateDate = DateTime.Now;
                ctx.SaveChanges();
                await PostTransformedData(ctx);
                _log.Info("Reduced Api Calls by Hashing. Total:{0}. File:{1}", ProcessedData.Count, file.Uri);
                ApiData.Clear();
                ProcessedData.Clear();
                InsertedIds.Clear();
                lstRowsToPostActions.Clear();
                lstRowsTransformingActions.Clear();
            }
            catch (Exception ex)
            {
                _log.Info("Error on PostTransformedData: {0}: ", ex.ToString());
                lock (lstErroredFilesLock)
                {
                    if (!lstErroredFiles.Contains(fileEntity))
                        lstErroredFiles.Add(fileEntity);
                }
            }
        }

        private static void TransformExcelFile(ICollection<DataMapAgent> dataMapAgents, Models.File fileEntity, string tempFileFullPath)
        {
            using (CsvHelper.CsvReader reader = new CsvHelper.CsvReader(new CsvHelper.Excel.ExcelParser(tempFileFullPath, null)))
            {
                ReadAndTransformFile(dataMapAgents, fileEntity, reader);
            }
        }

        private static void TransformFile(ICollection<DataMapAgent> dataMapAgents, Models.File fileEntity, string strFileText)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            using (StringReader strReader = new StringReader(strFileText))
            {
                using (CsvHelper.CsvReader reader = new CsvHelper.CsvReader(strReader))
                {
                    _processCounter.Add(fileEntity.Id, new ProcessCounter());
                    ReadAndTransformFile(dataMapAgents, fileEntity, reader);
                }
            }
            watch.Stop();
            var elapsed = watch.Elapsed;
        }

        private static void ReadAndTransformFile(ICollection<DataMapAgent> dataMapAgents, Models.File fileEntity, CsvReader reader)
        {
            IOrderedEnumerable<DataMapAgent> orderedDataMapAgents = dataMapAgents.OrderBy(datamaps => datamaps.ProcessingOrder);

            int rowNum = 1;
            while (reader.Read())
            {
                Dictionary<string, string> currentRowDictionary = new Dictionary<string, string>();
                var headers = reader.FieldHeaders;
                var currentRecord = reader.CurrentRecord;
                foreach (var singleHeader in reader.FieldHeaders)
                {
                    currentRowDictionary.Add(singleHeader, reader[singleHeader]);
                }
                rowNum++;
                foreach (var singleDataMapAgent in orderedDataMapAgents)
                {
                    _log.Info("Processing Data Map Agent: {0}. Agent: {1}. Data Map: {2}. Entity: {3}. Row #: {4}",
                        singleDataMapAgent.DataMap.Id, singleDataMapAgent.AgentId, singleDataMapAgent.DataMapId, singleDataMapAgent.DataMap.Entity.Name,
                        rowNum);
                    var entity = singleDataMapAgent.DataMap.Entity;
                    var dataMap = singleDataMapAgent.DataMap;
                    Action tskGeneratedRow = new Action(() =>
                    {
                        JToken generatedRow = ProcessCSVRow(entity, dataMap, currentRowDictionary);
                        RemoveCustomHints(ref generatedRow, headers, currentRecord);
                        lock (ApiDataLock)
                        {
                            ApiData.Add(new ResultingMapInfo()
                            {
                                Key = entity,
                                Value = generatedRow,
                                FileEntity = fileEntity,
                                RowNumber = rowNum,
                                ProcessingOrder = singleDataMapAgent.ProcessingOrder
                            });
                        }
                    });
                    lstRowsTransformingActions.Add(tskGeneratedRow);
                    if (lstRowsTransformingActions.Count == numberOfSimultaneousTasks)
                    {
                        Parallel.Invoke(parallelOptions, lstRowsTransformingActions.ToArray());
                        lstRowsTransformingActions.Clear();
                    }
                }
                if (lstRowsTransformingActions.Count == numberOfSimultaneousTasks)
                {
                    Parallel.Invoke(parallelOptions, lstRowsTransformingActions.ToArray());
                    lstRowsTransformingActions.Clear();
                }
            }
            if (lstRowsTransformingActions.Count > 0)
            {
                Parallel.Invoke(parallelOptions, lstRowsTransformingActions.ToArray());
                lstRowsTransformingActions.Clear();
            }
        }

        private static int GetNumberOfSimultaneousTasks()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings["SimultaneousTasks"]);
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

                                    foreach (var subProp in prop.Value)
                                    {
                                        bool required = false;

                                        if (subProp.Contains("_required"))
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

                                        if (required)
                                        {
                                            ((JObject)subProp).Property("_required").Remove();
                                        }
                                    }

                                    foreach (JToken node in removeList)
                                    {
                                        node.Remove();
                                    }
                                }
                            }
                            RemoveRequiredProperty(subToken, headers, currentRecord, level + 1);
                        }

                        break;
                    case JTokenType.Array:
                        foreach (JToken subToken in token)
                        {
                            RemoveRequiredProperty(subToken, headers, currentRecord, level + 1);
                        }
                        break;
                    case JTokenType.Property:
                        break;
                    default:
                        _log.Info("Token type: {0}", token.Type);
                        break;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error in RemoveRequiredProperty");
            }
        }


        private static JToken ProcessCSVRow(Entity entity, DataMap dataMap, Dictionary<string, string> reader)
        {
            JToken originalMap = JToken.Parse(dataMap.Map);
            JToken result = originalMap.DeepClone();
            TransformCSVRow(originalMap, ref result, reader);
            return result;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _log.Info("An unhandled exception has occurred: " + ((Exception)e.ExceptionObject).ToString());
        }

        private static void TransformCSVRow(JToken originalMap, ref JToken outputData, Dictionary<string, string> reader,
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
                                    if (!reader.ContainsKey(strColumnName))
                                        lstMissingColumnsInCSV.Add(strColumnName);
                                    else
                                        fieldValue = reader[strColumnName];
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

        private static void SetFieldValue(JToken originalMap, JToken outputData, Dictionary<string, string> reader,
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

        private static string GetValueFromLookupTable(string lookupTable, string lookupColumn,
            Dictionary<string, string> csvRow)
        {
            string result = string.Empty;
            string valueInCSV = csvRow[lookupColumn];
            var matchingRecord = MappingLookups.Where(p => p.GroupSet == lookupTable && p.Key.Trim() == valueInCSV).FirstOrDefault();
            if (matchingRecord != null)
                result = matchingRecord.Value;
            return result;
        }
    }

    public class ResultingMapInfo
    {
        public DataFlow.Models.File FileEntity { get; set; }
        public Entity Key { get; set; }
        public int ProcessingOrder { get; set; }
        public int RowNumber { get; set; }
        public JToken Value { get; set; }
    }

    public class ProcessCounter
    {
        public ProcessCounter()
        {
            Success = 0; Exists = 0; Error = 0;
        }
        public int Success { get; set; }
        public int Exists { get; set; }
        public int Error { get; set; }

    }
}
