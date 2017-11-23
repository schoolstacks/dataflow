using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace DataFlow.Web.Controllers
{
    public class AgentController : BaseController
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly EdFiService edFiService;

        public AgentController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
        }

        public ActionResult Index()
        {
            var agents = dataFlowDbContext.Agents
                .Include(x=>x.File)
                .ToList();

            ViewBag.Agents = GetAgentList;

            return View(agents);
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase File, string Agents)
        {
            TempData["FileStatus"] = string.Empty;

            try
            {
                if (File.ContentLength > 0)
                {
                    var azureFileConnectionString = ConfigurationManager.ConnectionStrings["storageConnection"].ConnectionString;
                    var shareName = ConfigurationManager.AppSettings["azureShareName"];

                    var agentId = Convert.ToInt32(Agents);

                    var agent = dataFlowDbContext.Agents
                        .FirstOrDefault(x => x.Id == agentId);

                    var storageAccount = CloudStorageAccount.Parse(azureFileConnectionString);
                    var fileClient = storageAccount.CreateCloudFileClient();
                    var fileShare = fileClient.GetShareReference(shareName);

                    if (!fileShare.Exists())
                    {
                        TempData["FileStatus"] = "File share does not exist!";
                    }
                    else
                    {
                        var fileDirectoryRoot = fileShare.GetRootDirectoryReference();
                        var fileAgentDirectory = fileDirectoryRoot.GetDirectoryReference(agent.Queue.ToString());

                        fileAgentDirectory.CreateIfNotExists();
                        var cloudFile = fileAgentDirectory.GetFileReference(File.FileName);
                        cloudFile.UploadFromStream(File.InputStream);
                        var recordCount = TotalLines(File.InputStream);

                        LogFile(agent.Id, File.FileName, cloudFile.StorageUri.PrimaryUri.ToString(), "UPLOADED", recordCount);

                        TempData["FileStatus"] = "File successfully uploaded: " + File.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["FileStatus"] = "Error: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

        private void LogFile(int agentId, string fileName, string url, string status, int rows)
        {
            var fileLog = new DataFlow.Models.File()
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

        private List<SelectListItem> GetAgentList
        {
            get
            {
                var entityList = new List<SelectListItem>();
                entityList.Add(new SelectListItem() { Text = "Select Agent", Value = string.Empty });
                entityList.AddRange(dataFlowDbContext.Agents.Select(x =>
                    new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }));

                return entityList;
            }
        }
    }
}