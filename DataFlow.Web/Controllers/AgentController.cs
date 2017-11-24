using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Models;
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
                .Include(x=>x.Files)
                .ToList();

            ViewBag.Agents = GetAgentList;

            return View(agents);
        }

        public ActionResult Add()
        {
            var agent = new DataFlow.Models.Agent();

            ViewBag.DataMaps = GetDataMapList;

            return View(agent);
        }

        public ActionResult Edit(int id)
        {
            var agent = dataFlowDbContext.Agents
                .Include(x => x.AgentSchedules)
                .Include(x => x.DataMapAgents)
                .Include(x => x.DataMapAgents.Select(y => y.DataMap))
                .FirstOrDefault(x => x.Id == id);

            ViewBag.DataMaps = GetDataMapList;

            return View(agent);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var agent = dataFlowDbContext.Agents.FirstOrDefault(x => x.Id == id);
            if (agent != null)
            {
                dataFlowDbContext.Agents.Remove(agent);
                await dataFlowDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(DataFlow.Models.Agent vm, string btnAddMap, string ddlDataMaps, string dataMapAgentNextOrder,
            string btnAddSchedule, string ddlDay, string ddlHour, string ddlMinute)
        {
            ViewBag.DataMaps = GetDataMapList;
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ModelError", "There was an error saving this agent.");
                return View("Edit", vm);
            }

            var isUpdate = false;

            var agent = new DataFlow.Models.Agent();
            if (vm.Id > 0)
            {
                isUpdate = true;
                agent = dataFlowDbContext.Agents.FirstOrDefault(x => x.Id == vm.Id);
                agent.Id = vm.Id;
            }

            agent.Name = vm.Name;
            agent.AgentTypeCode = !string.IsNullOrWhiteSpace(vm.AgentTypeCode) ? vm.AgentTypeCode : "SFTP";
            agent.Url = vm.Url;
            agent.Username = vm.Username;
            agent.Password = vm.Password;
            agent.Directory = vm.Directory;
            agent.FilePattern = vm.FilePattern;
            agent.Enabled = vm.Enabled;
            agent.Queue = vm.Queue;
            agent.Custom = vm.Custom;

            if (!isUpdate)
            {
                agent.Created = DateTime.Now;
            }

            if (btnAddMap != null && int.TryParse(ddlDataMaps, out var dataMapId))
            {
                var lastProcessOrder = Convert.ToInt32(dataMapAgentNextOrder) + 1;

                agent.DataMapAgents = new List<DataMapAgent>
                {
                    new DataMapAgent
                    {
                        DataMapId = dataMapId,
                        ProcessingOrder = lastProcessOrder
                    }
                };
            }

            if (btnAddSchedule != null && int.TryParse(ddlDay, out var day) && int.TryParse(ddlHour, out var hour) && int.TryParse(ddlMinute, out var minute))
            {
                agent.AgentSchedules = new List<AgentSchedule>
                {
                    new AgentSchedule
                    {
                        Day = day,
                        Hour = hour,
                        Minute = minute
                    }
                };
            }

            dataFlowDbContext.Agents.AddOrUpdate(agent);
            dataFlowDbContext.SaveChanges();

            return RedirectToAction("Edit", new{ agent.Id });
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

        private List<SelectListItem> GetDataMapList
        {
            get
            {
                var entityList = new List<SelectListItem>();
                entityList.Add(new SelectListItem() { Text = "Select Map", Value = string.Empty });
                entityList.AddRange(dataFlowDbContext.DataMaps.Select(x =>
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