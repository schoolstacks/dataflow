using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Web.Helpers;
using DataFlow.Web.Models;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class LogController : BaseController
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly EdFiService edFiService;

        public LogController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
        }

        public ActionResult Index()
        {
            var vm = new LogsViewModel()
            {
                Files = dataFlowDbContext.Files.Include(x => x.Agent).Take(100).OrderByDescending(x => x.CreateDate).ToList(),
                LogIngestions = dataFlowDbContext.LogIngestions.Take(100).OrderByDescending(x => x.Date).ToList(),
                LogApplications = dataFlowDbContext.LogApplications.Take(100).OrderByDescending(x => x.Date).ToList()
            };

            return View(vm);
        }
    }
}