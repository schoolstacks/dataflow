using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;

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

        // GET: Agent
        public ActionResult Index()
        {
            var agents = dataFlowDbContext.Agents
                .Include(x=>x.File)
                .ToList();

            return View(agents);
        }
    }
}