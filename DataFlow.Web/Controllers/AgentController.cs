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
using DataFlow.Common;
using DataFlow.Common.DAL;
using DataFlow.Common.ExtensionMethods;
using DataFlow.Models;
using DataFlow.Web.Helpers;
using DataFlow.Web.Models;
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
        private readonly string EncryptionKey;

        public AgentController(DataFlowDbContext dataFlowDbContext, IBaseServices baseService) : base(baseService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.EncryptionKey = WebConfigAppSettingsService.GetSetting<string>(Constants.AppSettingEncryptionKey);
        }

        public ActionResult Index()
        {
            var agents = dataFlowDbContext.Agents
                .Include(x => x.Files)
                .OrderBy(x => x.Name)
                .ToList();

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
                LogService.Error("Error retrieving agent files.", ex);
                return Json(new { success = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            var agent = new Agent();
            var vm = MapperService.Map<AgentViewModel>(agent);

            ViewBag.DataMaps = GetDataMapList;
            ViewBag.AgentTypes = GetAgentTypes;
            ViewBag.AgentActions = GetAgentActions;

            return View(vm);
        }

        public ActionResult Edit(int id, bool? success)
        {
            var agent = dataFlowDbContext.Agents
                .Include(x => x.AgentSchedules)
                .Include(x => x.DataMapAgents)
                .Include(x => x.DataMapAgents.Select(y => y.DataMap))
                .FirstOrDefault(x => x.Id == id);

            if (agent == null)
                return RedirectToAction("Index");

            agent.Password = Encryption.Decrypt(agent.Password, EncryptionKey);

            ViewBag.DataMaps = GetDataMapList;
            ViewBag.AgentTypes = GetAgentTypes;
            ViewBag.AgentActions = GetAgentActions;

            var vm = MapperService.Map<AgentViewModel>(agent);

            if (success.GetValueOrDefault(false))
            {
                vm.FormResult = new FormResult()
                {
                    ShowInfoMessage = true,
                    IsSuccess = true,
                    InfoMessage = $"Agent {agent.Name} has been saved!."
                };
            }

            return View(vm);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var agent = dataFlowDbContext.Agents.FirstOrDefault(x => x.Id == id);
            if (agent != null)
            {
                LogService.Info(LogTemplates.InfoCrud("Agent", agent.Name, agent.Id,
                    LogTemplates.EntityAction.Deleted));

                dataFlowDbContext.Agents.Remove(agent);
                await dataFlowDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AgentViewModel vm, string btnAddMap, string ddlDataMaps, string dataMapAgentNextOrder,
            string btnAddSchedule, string ddlDay, string ddlHour, string ddlMinute)
        {
            var validate = Validate(vm);
            ModelState.Merge(validate);

            if (!ModelState.IsValid)
            {
                ViewBag.DataMaps = GetDataMapList;
                ViewBag.AgentTypes = GetAgentTypes;
                ViewBag.AgentActions = GetAgentActions;
                return View(vm);
            }

            var agent = SaveAgent(vm, btnAddMap, ddlDataMaps, dataMapAgentNextOrder, btnAddSchedule, ddlDay, ddlHour, ddlMinute);

            return RedirectToAction("Edit", new { agent.Id, success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgentViewModel vm, string btnAddMap, string ddlDataMaps, string dataMapAgentNextOrder,
            string btnAddSchedule, string ddlDay, string ddlHour, string ddlMinute)
        {
            var validate = Validate(vm);
            ModelState.Merge(validate);

            if (!ModelState.IsValid)
            {
                ViewBag.DataMaps = GetDataMapList;
                ViewBag.AgentTypes = GetAgentTypes;
                ViewBag.AgentActions = GetAgentActions;
                
                return View(vm);
            }

            var agent = SaveAgent(vm, btnAddMap, ddlDataMaps, dataMapAgentNextOrder, btnAddSchedule, ddlDay, ddlHour, ddlMinute);

            return RedirectToAction("Edit", new { agent.Id, success = true });
        }

        private AgentViewModel SaveAgent(AgentViewModel vm, string btnAddMap, string ddlDataMaps, string dataMapAgentNextOrder,
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
            agent.Password = Encryption.Encrypt(vm.Password, EncryptionKey);
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

            var savevm = MapperService.Map<AgentViewModel>(agent);


            LogService.Info(LogTemplates.InfoCrud("Agent", agent.Name, agent.Id,
                isUpdate ? LogTemplates.EntityAction.Modified : LogTemplates.EntityAction.Added));



            return savevm;
        }

        public ModelStateDictionary Validate(AgentViewModel agent)
        {
            var msd = new ModelStateDictionary();

            if(string.IsNullOrWhiteSpace(agent.Name))
                msd.AddModelError("Name", "Please enter a name for this agent.");

            if (string.IsNullOrWhiteSpace(agent.AgentTypeCode))
                msd.AddModelError("AgentTypeCode", "Please select agent type.");

            switch (agent.AgentTypeCode)
            {
                case "FTPS":
                case "SFTP":
                    if (string.IsNullOrWhiteSpace(agent.Url))
                        msd.AddModelError("Url", "Please enter a url or connection string.");

                    if (string.IsNullOrWhiteSpace(agent.Username))
                        msd.AddModelError("Username", "Please enter a username.");

                    if (string.IsNullOrWhiteSpace(agent.Password))
                        msd.AddModelError("Password", "Please enter a password.");

                    if (string.IsNullOrWhiteSpace(agent.Directory))
                        msd.AddModelError("Directory", "Please enter a directory.");

                    if (string.IsNullOrWhiteSpace(agent.FilePattern))
                        msd.AddModelError("FilePattern", "Please enter a file pattern.");
                    break;
                case "Chrome":
                    if (string.IsNullOrWhiteSpace(agent.AgentAction))
                        msd.AddModelError("AgentAction", "Please select an action.");

                    if (string.IsNullOrWhiteSpace(agent.Custom))
                        msd.AddModelError("Custom", "Please enter the parameters.");
                    break;
            }

            return msd;
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

                        LogService.Info($"File {File.FileName} was uploaded to {agent.Name} (Id: {agent.Id}).");

                        TempData["FileStatus"] = "File successfully uploaded: " + File.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.Error("Error Uploading File", ex);
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
                agentTypes.AddRange(new[] { "Chrome","Manual", "SFTP", "FTPS" }.Select(x =>
                      new SelectListItem
                      {
                          Text = x,
                          Value = x
                      }));

                return agentTypes;
            }
        }

        private List<SelectListItem> GetAgentActions
        {
            get
            {
                var agentActions = new List<SelectListItem>();
                agentActions.Add(new SelectListItem { Text = "Select Action", Value = string.Empty });
                agentActions.AddRange(new[] { "GET", "POST" }.Select(x =>
                    new SelectListItem
                    {
                        Text = x,
                        Value = x
                    }));

                return agentActions;
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