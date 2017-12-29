using System.Data.Entity;
using System.Linq;
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

        public LogController(DataFlowDbContext dataFlowDbContext, IBaseServices baseService) : base(baseService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
        }

        public ActionResult Index()
        {
            var vm = new LogsViewModel()
            {
                Files = dataFlowDbContext.Files.Include(x => x.Agent).Take(1000).OrderByDescending(x => x.CreateDate).ToList(),
                LogIngestions = dataFlowDbContext.LogIngestions.Take(1000).OrderByDescending(x => x.Date).ToList(),
                NLogs = dataFlowDbContext.NLogs.Take(1000).OrderByDescending(x => x.Logged).ToList()
            };

            return View(vm);
        }
    }
}