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
using DataFlow.Common.ExtensionMethods;
using DataFlow.Models;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;
using Microsoft.WindowsAzure.Storage;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using File = DataFlow.Models.File;

namespace DataFlow.Web.Controllers
{
    public class AgentController : BaseController
    {
        private readonly DataFlowDbContext dataFlowDbContext;

        public AgentController(DataFlowDbContext dataFlowDbContext, IBaseServices baseService) : base(baseService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
        }

        public ActionResult Index()
        {
            var agents = dataFlowDbContext.Agents
                .Include(x => x.Files)
                .OrderBy(x => x.Name)
                .ToList();

            //agents.ForEach(x =>
            //{
            //    x.Password = Common.Helpers.Encryption.EncryptString(x.Password, WebConfigAppSettingsService.GetSetting<string>(Constants.AppSettingEncryptionKey));
            //    dataFlowDbContext.Agents.AddOrUpdate(x);
            //});
            //dataFlowDbContext.SaveChanges();

            ViewBag.Agents = GetAgentList;

            return View(agents);
        }

        public ActionResult ToggleAgentStatus(int id)
        {
            var agent = dataFlowDbContext.Agents.FirstOrDefault(x => x.Id == id);
            if (agent != null)
            {
                agent.Enabled = !agent.Enabled;

                dataFlowDbContext.Agents.Add(agent);
                dataFlowDbContext.Entry(agent).State = EntityState.Modified;
                dataFlowDbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult TestAgentConnection(string url, string username, string password, string directory, string filePattern)
        {
            try
            {
                var files = GetAgentFiles(url, username, password, directory, filePattern);
                return Json(new { success = true, files }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving agent files.", ex);
                return Json(new { success = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            var agent = new Agent();

            ViewBag.DataMaps = GetDataMapList;
            ViewBag.AgentTypes = GetAgentTypes;

            return View(agent);
        }

        public ActionResult Edit(int id)
        {
            var agent = dataFlowDbContext.Agents
                .Include(x => x.AgentSchedules)
                .Include(x => x.DataMapAgents)
                .Include(x => x.DataMapAgents.Select(y => y.DataMap))
                .FirstOrDefault(x => x.Id == id);

            if (agent == null)
                return RedirectToAction("Index");

            agent.Password = Common.Helpers.Encryption.DecryptString(agent.Password, WebConfigAppSettingsService.GetSetting<string>(Constants.AppSettingEncryptionKey));

            ViewBag.DataMaps = GetDataMapList;
            ViewBag.AgentTypes = GetAgentTypes;

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
        public ActionResult Add(Agent vm, string btnAddMap, string ddlDataMaps, string dataMapAgentNextOrder,
            string btnAddSchedule, string ddlDay, string ddlHour, string ddlMinute)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DataMaps = GetDataMapList;
                ViewBag.AgentTypes = GetAgentTypes;
                return View(vm);
            }

            var agent = SaveAgent(vm, btnAddMap, ddlDataMaps, dataMapAgentNextOrder, btnAddSchedule, ddlDay, ddlHour, ddlMinute);

            return RedirectToAction("Edit", new { agent.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Agent vm, string btnAddMap, string ddlDataMaps, string dataMapAgentNextOrder,
            string btnAddSchedule, string ddlDay, string ddlHour, string ddlMinute)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DataMaps = GetDataMapList;
                ViewBag.AgentTypes = GetAgentTypes;
                return View(vm);
            }

            var agent = SaveAgent(vm, btnAddMap, ddlDataMaps, dataMapAgentNextOrder, btnAddSchedule, ddlDay, ddlHour, ddlMinute);

            return RedirectToAction("Edit", new { agent.Id });
        }

        private Agent SaveAgent(Agent vm, string btnAddMap, string ddlDataMaps, string dataMapAgentNextOrder,
            string btnAddSchedule, string ddlDay, string ddlHour, string ddlMinute)
        {
            var isUpdate = false;

            var agent = new Agent();
            if (vm.Id > 0)
            {
                isUpdate = true;
                agent = dataFlowDbContext.Agents.FirstOrDefault(x => x.Id == vm.Id);
                agent.Id = vm.Id;
            }

            agent.Name = vm.Name;
            agent.AgentTypeCode = vm.AgentTypeCode;
            agent.Url = vm.Url;
            agent.Username = vm.Username;
            agent.Password = Common.Helpers.Encryption.EncryptString(vm.Password, WebConfigAppSettingsService.GetSetting<string>(Constants.AppSettingEncryptionKey));
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

            return agent;
        }

        public async Task<ActionResult> DeleteDataMap(int agentId, int id)
        {
            var agentMap = dataFlowDbContext.DatamapAgents.FirstOrDefault(x => x.Id == id);

            if (agentMap != null)
            {
                dataFlowDbContext.DatamapAgents.Remove(agentMap);
                await dataFlowDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Edit", new { id = agentId });
        }

        public async Task<ActionResult> DeleteSchedule(int agentId, int id)
        {
            var agentScedhule = dataFlowDbContext.AgentSchedules.FirstOrDefault(x => x.Id == id);

            if (agentScedhule != null)
            {
                dataFlowDbContext.AgentSchedules.Remove(agentScedhule);
                await dataFlowDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Edit", new { id = agentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                Logger.Error("Error Uploading File", ex);
                TempData["FileStatus"] = "Error: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

        private List<SftpFile> GetAgentFiles(string url, string username, string password, string directory, string filePattern)
        {
            using (var ftpClient = new SftpClient(new ConnectionInfo(url, username, new PasswordAuthenticationMethod(username, password))))
            {
                ftpClient.Connect();

                if (ftpClient.IsConnected)
                {
                    filePattern = filePattern.Trim();
                    return ftpClient.ListDirectory(directory).Where(x => x.Name.IsLike(filePattern)).ToList();
                }
                throw new Exception("Ftp Client Cannot Connect");
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

        private List<SelectListItem> GetAgentTypes
        {
            get
            {
                var agentTypes = new List<SelectListItem>();
                agentTypes.Add(new SelectListItem { Text = "Select Type", Value = string.Empty });
                agentTypes.AddRange(new[] { "SFTP", "FTPS" }.Select(x =>
                      new SelectListItem
                      {
                          Text = x,
                          Value = x
                      }));

                return agentTypes;
            }
        }

        private List<SelectListItem> GetAgentList
        {
            get
            {
                var entityList = new List<SelectListItem>();
                entityList.Add(new SelectListItem { Text = "Select Agent", Value = string.Empty });
                entityList.AddRange(dataFlowDbContext.Agents.Select(x =>
                    new SelectListItem
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
                entityList.Add(new SelectListItem { Text = "Select Map", Value = string.Empty });
                entityList.AddRange(dataFlowDbContext.DataMaps.Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }));

                return entityList;
            }
        }
    }
}