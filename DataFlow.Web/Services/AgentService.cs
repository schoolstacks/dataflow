using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using DataFlow.Common.DAL;
using DataFlow.Common.Services;
using DataFlow.Common.Enums;
using DataFlow.Common.Helpers;
using DataFlow.Models;
using Microsoft.WindowsAzure.Storage;
using File = DataFlow.Models.File;

namespace DataFlow.Web.Services
{
    public class AgentService
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly ILogService LogService;

        public AgentService(DataFlowDbContext dataFlowDbContext, ILogService logService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.LogService = logService;

            if (LogService != null)
                LogService.Name = GetType().FullName;
        }

        public Tuple<bool,string> UploadFile(string fileName, System.IO.Stream fileStream, Agent agent)
        {
            if (agent != null)
            {
                switch (ConfigurationManager.AppSettings["FileMode"])
                {
                    case FileModeEnum.Local:
                        return UploadLocal(fileName, fileStream, agent);
                    case FileModeEnum.Azure:
                        return UploadToAzure(fileName, fileStream, agent);
                }
            }

            return new Tuple<bool, string>(false, "The agent provided was null.");
        }

        private Tuple<bool, string> UploadToAzure(string fileName, System.IO.Stream fileStream, Agent agent)
        {
            try
            {
                var azureFileConnectionString = ConfigurationManager.ConnectionStrings["storageConnection"].ConnectionString;
                var shareName = ConfigurationManager.AppSettings["azureShareName"];

                var storageAccount = CloudStorageAccount.Parse(azureFileConnectionString);
                var fileClient = storageAccount.CreateCloudFileClient();
                var fileShare = fileClient.GetShareReference(shareName);

                if (fileShare.Exists())
                {
                    var fileDirectoryRoot = fileShare.GetRootDirectoryReference();
                    var fileAgentDirectory = fileDirectoryRoot.GetDirectoryReference(agent.Queue.ToString());

                    fileAgentDirectory.CreateIfNotExists();
                    var cloudFile = fileAgentDirectory.GetFileReference(fileName);
                    cloudFile.UploadFromStream(fileStream);
                    var recordCount = TotalLines(fileStream);

                    LogFile(agent.Id, fileName, cloudFile.StorageUri.PrimaryUri.ToString(), FileStatusEnum.UPLOADED, recordCount);

                    var logMessage = $"File '{fileName}' was uploaded to '{cloudFile.StorageUri.PrimaryUri}' for Agent '{agent.Name}' (Id: {agent.Id}).";
                    LogService.Info(logMessage);
                    return new Tuple<bool, string>(true, logMessage);
                }

                var message = $"The file share '{fileShare}' does not exist.";
                return new Tuple<bool, string>(false, message);
            }
            catch (Exception ex)
            {
                var logMessage = $"Error Uploading File '{fileName}' to Azure for Agent '{agent.Name}'.";
                LogService.Error(logMessage, ex);
                return new Tuple<bool, string>(false, logMessage);
            }
        }

        private Tuple<bool, string> UploadLocal(string fileName, System.IO.Stream fileStream, Agent agent)
        {
            try
            {
                string uploadPath = PathUtility.EnsureTrailingSlash(ConfigurationManager.AppSettings["ShareName"]);
                uploadPath += PathUtility.EnsureTrailingSlash(agent.Queue.ToString());
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);
                string fullFilePath = Path.Combine(uploadPath, fileName);

                using (var file = System.IO.File.Create(fullFilePath))
                {
                    fileStream.Seek(0, SeekOrigin.Begin);
                    fileStream.CopyTo(file);
                }

                var recordCount = TotalLines(fileStream);

                LogFile(agent.Id, fileName, UrlUtility.ConvertLocalPathToUri(fullFilePath), FileStatusEnum.UPLOADED, recordCount);
                var logMessage = $"File '{fileName}' was uploaded to '{uploadPath}' for Agent '{agent.Name}' (Id: {agent.Id}).";
                if (LogService != null)
                    LogService.Info(logMessage);

                return new Tuple<bool, string>(true, logMessage);
            }
            catch (Exception ex)
            {
                var logMessage = $"Error Uploading File '{fileName}' to '{agent.Directory}' for Agent '{agent.Name}'.";
                LogService.Error(logMessage, ex);
                return new Tuple<bool, string>(false, logMessage);
            }
        }



        private void LogFile(int agentId, string fileName, string url, string status, int rows)
        {
            var fileLog = new File
            {
                AgentId = agentId,
                FileName = fileName,
                Url = url,
                Rows = rows,
                Status = status,
                CreateDate = DateTime.Now
            };
            dataFlowDbContext.Files.Add(fileLog);
            dataFlowDbContext.SaveChanges();

        }

        private int TotalLines(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using (StreamReader r = new StreamReader(stream))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }
    }
}