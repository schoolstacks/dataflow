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

            LogService.Name = GetType().FullName;
        }

        public Tuple<bool,string> UploadFile(HttpPostedFileBase file, Agent agent)
        {
            if (agent != null)
            {
                switch (ConfigurationManager.AppSettings["FileMode"])
                {
                    case FileModeEnum.Local:
                        return UploadLocal(file, agent);
                    case FileModeEnum.Azure:
                        return UploadToAzure(file, agent);
                }
            }

            return new Tuple<bool, string>(false, "The agent provided was null.");
        }

        private Tuple<bool, string> UploadToAzure(HttpPostedFileBase file, Agent agent)
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
                    var cloudFile = fileAgentDirectory.GetFileReference(file.FileName);
                    cloudFile.UploadFromStream(file.InputStream);
                    var recordCount = TotalLines(file.InputStream);

                    LogFile(agent.Id, file.FileName, cloudFile.StorageUri.PrimaryUri.ToString(), FileStatusEnum.UPLOADED, recordCount);

                    var logMessage = $"File '{file.FileName}' was uploaded to '{cloudFile.StorageUri.PrimaryUri}' for Agent '{agent.Name}' (Id: {agent.Id}).";
                    LogService.Info(logMessage);
                    return new Tuple<bool, string>(true, logMessage);
                }

                var message = $"The file share '{fileShare}' does not exist.";
                return new Tuple<bool, string>(false, message);
            }
            catch (Exception ex)
            {
                var logMessage = $"Error Uploading File '{file.FileName}' to Azure for Agent '{agent.Name}'.";
                LogService.Error(logMessage, ex);
                return new Tuple<bool, string>(false, logMessage);
            }
        }

        private Tuple<bool, string> UploadLocal(HttpPostedFileBase file, Agent agent)
        {
            try
            {
                string uploadPath = PathUtility.EnsureTrailingSlash(ConfigurationManager.AppSettings["ShareName"]);
                uploadPath += PathUtility.EnsureTrailingSlash(agent.Queue.ToString());
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                file.SaveAs(Path.Combine(uploadPath, file.FileName));
                var recordCount = TotalLines(file.InputStream);

                LogFile(agent.Id, file.FileName, uploadPath, FileStatusEnum.UPLOADED, recordCount);
                var logMessage = $"File '{file.FileName}' was uploaded to '{uploadPath}' for Agent '{agent.Name}' (Id: {agent.Id}).";
                LogService.Info(logMessage);

                return new Tuple<bool, string>(true, logMessage);
            }
            catch (Exception ex)
            {
                var logMessage = $"Error Uploading File '{file.FileName}' to '{agent.Directory}' for Agent '{agent.Name}'.";
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
            using (StreamReader r = new StreamReader(stream))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }
    }
}