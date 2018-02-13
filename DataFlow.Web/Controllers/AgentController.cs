using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataFlow.Common;
using DataFlow.Common.DAL;
using DataFlow.Common.Enums;
using DataFlow.Common.ExtensionMethods;
using DataFlow.Models;
using DataFlow.Web.Helpers;
using DataFlow.Web.Models;
using DataFlow.Web.Services;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace DataFlow.Web.Controllers
{
    public class AgentController : BaseController
    {
        private readonly AgentService _agentService;
        private readonly string _encryptionKey;

        public AgentController()
        {
            _encryptionKey = WebConfigAppSettingsService.GetSetting<string>(Constants.AppSettingEncryptionKey);
            _agentService = new AgentService(this.DataFlowDbContext, this.LogService);


            //this.MapperService = new AutoMapper.Mapper()


            //AutoMapper.AutoMapperModule
        }

        public ActionResult Index()
        {
            var agents = this.DataFlowDbContext.Agents
                .Include(x => x.Files)
                .OrderBy(x => x.Name)
                .ToList();

            ViewBag.Agents = GetAgentList;

            return View(agents);
        }

        public ActionResult ToggleAgentStatus(int id)
        {
            var agent = this.DataFlowDbContext.Agents.FirstOrDefault(x => x.Id == id);
            if (agent != null)
            {
                agent.Enabled = !agent.Enabled;

                this.DataFlowDbContext.Agents.Add(agent);
                this.DataFlowDbContext.Entry(agent).State = EntityState.Modified;
                this.DataFlowDbContext.SaveChanges();
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
            ViewBag.AgentChromes = GetAgentChromes;

            return View(vm);
        }

        public ActionResult Edit(int id, bool? success)
        {
            var agent = this.DataFlowDbContext.Agents
                .Include(x => x.AgentSchedules)
                .Include(x => x.DataMapAgents)
                .Include(x => x.DataMapAgents.Select(y => y.DataMap))
                .Include(x => x.AgentAgentChromes.Select(y => y.AgentChrome))
                .FirstOrDefault(x => x.Id == id);

            if (agent == null)
                return RedirectToAction("Index");

            if (agent.Password != null)
                agent.Password = Encryption.Decrypt(agent.Password, _encryptionKey);

            ViewBag.DataMaps = GetDataMapList;
            ViewBag.AgentTypes = GetAgentTypes;
            ViewBag.AgentActions = GetAgentActions;
            ViewBag.AgentChromes = GetAgentChromes;

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
            var agent = this.DataFlowDbContext.Agents.FirstOrDefault(x => x.Id == id);
            if (agent != null)
            {
                LogService.Info(LogTemplates.InfoCrud("Agent", agent.Name, agent.Id,
                    LogTemplates.EntityAction.Deleted));

                this.DataFlowDbContext.Agents.Remove(agent);
                await this.DataFlowDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AgentViewModel vm, string btnAddMap, string ddlDataMaps, string btnAddChrome, string ddlAgentChromes, string dataMapAgentNextOrder,
            string btnAddSchedule, string ddlDay, string ddlHour, string ddlMinute)
        {
            var validate = Validate(vm);
            ModelState.Merge(validate);

            if (!ModelState.IsValid)
            {
                ViewBag.DataMaps = GetDataMapList;
                ViewBag.AgentTypes = GetAgentTypes;
                ViewBag.AgentActions = GetAgentActions;
                ViewBag.AgentChromes = GetAgentChromes;
                return View(vm);
            }

            var agent = SaveAgent(vm, btnAddMap, ddlDataMaps, btnAddChrome, ddlAgentChromes, dataMapAgentNextOrder, btnAddSchedule, ddlDay, ddlHour, ddlMinute);

            return RedirectToAction("Edit", new { agent.Id, success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AgentViewModel vm, string btnAddMap, string ddlDataMaps, string btnAddChrome, string ddlAgentChromes, string dataMapAgentNextOrder, 
            string btnAddSchedule, string ddlDay, string ddlHour, string ddlMinute)
        {
            var validate = Validate(vm);
            ModelState.Merge(validate);

            if (!ModelState.IsValid)
            {
                ViewBag.DataMaps = GetDataMapList;
                ViewBag.AgentTypes = GetAgentTypes;
                ViewBag.AgentActions = GetAgentActions;
                ViewBag.AgentChromes = GetAgentChromes;
                
                return View(vm);
            }

            var agent = SaveAgent(vm, btnAddMap, ddlDataMaps, btnAddChrome, ddlAgentChromes, dataMapAgentNextOrder, btnAddSchedule, ddlDay, ddlHour, ddlMinute);

            return RedirectToAction("Edit", new { agent.Id, success = true });
        }

        private AgentViewModel SaveAgent(AgentViewModel vm, string btnAddMap, string ddlDataMaps, string btnAddChrome, string ddlAgentChromes, string dataMapAgentNextOrder, 
            string btnAddSchedule, string ddlDay, string ddlHour, string ddlMinute)
        {
            var isUpdate = false;

            var agent = new Agent();
            if (vm.Id > 0)
            {
                isUpdate = true;
                agent = this.DataFlowDbContext.Agents.FirstOrDefault(x => x.Id == vm.Id);
                agent.Id = vm.Id;
            }

            agent.Name = vm.Name;
            agent.AgentTypeCode = vm.AgentTypeCode;
            agent.AgentAction = vm.AgentAction;
            agent.Url = vm.Url;
            agent.LoginUrl = vm.LoginUrl;
            agent.Username = vm.Username;
            if (vm.Password != null)
                agent.Password = Encryption.Encrypt(vm.Password, _encryptionKey);
            agent.Directory = vm.Directory ?? GetManualAgentBaseDirectory(agent);
            agent.FilePattern = vm.FilePattern;
            agent.Enabled = vm.Enabled;
            agent.Queue = Guid.NewGuid();
            agent.Custom = vm.Custom;


            if (!isUpdate)
            {
                agent.Created = DateTime.Now;
            }

            int agentChromeId;
            if (btnAddChrome != null && int.TryParse(ddlAgentChromes, out agentChromeId))
            {
                agent.AgentAgentChromes = new List<AgentAgentChrome>
                {
                    new AgentAgentChrome
                    {
                        AgentChromeId = agentChromeId
                    }
                };
            }

            int dataMapId;
            if (btnAddMap != null && int.TryParse(ddlDataMaps, out dataMapId))
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

            int day; int minute; int hour;
            if (btnAddSchedule != null && int.TryParse(ddlDay, out day) && int.TryParse(ddlHour, out hour) && int.TryParse(ddlMinute, out minute))
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

            this.DataFlowDbContext.Agents.AddOrUpdate(agent);
            this.DataFlowDbContext.SaveChanges();

            var savevm = MapperService.Map<AgentViewModel>(agent);

            LogService.Info(LogTemplates.InfoCrud("Agent", agent.Name, agent.Id,
                isUpdate ? LogTemplates.EntityAction.Modified : LogTemplates.EntityAction.Added));

            return savevm;
        }

        private string GetManualAgentBaseDirectory(Agent agent)
        {
            if (agent.AgentTypeCode == AgentTypeCodeEnum.Manual)
            {
                if (string.IsNullOrWhiteSpace(agent.Directory))
                {
                    var directoryPath = string.Empty;

                    var baseDirectory = WebConfigAppSettingsService.GetSetting<string>("ShareName");
                    if (string.IsNullOrWhiteSpace(baseDirectory))
                        baseDirectory = Server.MapPath("~/App_Data");

                    directoryPath = Path.Combine(baseDirectory, "Agents", Guid.NewGuid().ToString().ToUpper());

                    if (Directory.Exists(directoryPath) == false)
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    return directoryPath;
                }
            }

            return string.Empty;
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
                case AgentTypeCodeEnum.FTPS:
                case AgentTypeCodeEnum.SFTP:
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
                case AgentTypeCodeEnum.Chrome:
                    if (string.IsNullOrWhiteSpace(agent.AgentAction))
                        msd.AddModelError("AgentAction", "Please select an action.");

                    break;
            }

            return msd;
        }

        public async Task<ActionResult> DeleteDataMap(int agentId, int id)
        {
            var agentMap = this.DataFlowDbContext.DatamapAgents.FirstOrDefault(x => x.Id == id);

            if (agentMap != null)
            {
                LogService.Info($"Data Map {agentMap.DataMap.Name} was removed from {agentMap.Agent.Name}.");

                this.DataFlowDbContext.DatamapAgents.Remove(agentMap);
                await this.DataFlowDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Edit", new { id = agentId });
        }

        public async Task<ActionResult> DeleteSchedule(int agentId, int id)
        {
            var agentScedhule = this.DataFlowDbContext.AgentSchedules.FirstOrDefault(x => x.Id == id);

            if (agentScedhule != null)
            {
                var dayOfWeek = Enum.GetName(typeof(DayOfWeek), agentScedhule.Day);
                LogService.Info($"Schedule that occured every {dayOfWeek} at {Convert.ToString(agentScedhule.Hour).PadLeft(2, '0')}:{Convert.ToString(agentScedhule.Minute).PadLeft(2, '0')} was removed from {agentScedhule.Agent.Name}.");

                this.DataFlowDbContext.AgentSchedules.Remove(agentScedhule);
                await this.DataFlowDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Edit", new { id = agentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFile(HttpPostedFileBase File, string Agents)
        {
            TempData["FormResult"] = new FormResult()
            {
                IsSuccess = false, ShowInfoMessage = false, InfoMessage = string.Empty
            };

            var formResult = new FormResult();

            try
            {
                if (File.ContentLength > 0)
                {
                    var agentId = Convert.ToInt32(Agents);
                    var agent = this.DataFlowDbContext.Agents.FirstOrDefault(x => x.Id == agentId);

                    var uploadFile = _agentService.UploadFile(File.FileName, File.InputStream, agent);

                    formResult.IsSuccess = uploadFile.Item1;
                    formResult.ShowInfoMessage = true;
                    formResult.InfoMessage = uploadFile.Item2;
                }
            }
            catch (Exception ex)
            {
                LogService.Error("Error Manually Uploading File to Agent", ex);

                formResult.IsSuccess = false;
                formResult.ShowInfoMessage = true;
                formResult.InfoMessage = $"There was an error while processing your upload. If you continue to encounter this error, please contact your supervisor.";
            }

            TempData["FormResult"] = formResult;

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

        private List<SelectListItem> GetAgentTypes
        {
            get
            {
                var agentTypes = new List<SelectListItem>();
                agentTypes.Add(new SelectListItem { Text = "Select Type", Value = string.Empty });
                agentTypes.AddRange(AgentTypeCodeEnum.ToList().Select(x =>
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
                entityList.AddRange(this.DataFlowDbContext.Agents.Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }));

                return entityList;
            }
        }

        private List<SelectListItem> GetAgentChromes
        {
            get
            {
                var entityList = new List<SelectListItem>();
                entityList.Add(new SelectListItem { Text = "Select Chrome Agent", Value = string.Empty });
                entityList.AddRange(this.DataFlowDbContext.AgentChromes.Select(x =>
                    new SelectListItem
                    {
                        Text = x.AgentUuid.ToString(),
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
                entityList.AddRange(this.DataFlowDbContext.DataMaps.Select(x =>
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