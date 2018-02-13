using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Web.Helpers;
using DataFlow.Web.Models;
using DataFlow.Web.Services;
using DataFlow.Common.Enums;

namespace DataFlow.Web.Controllers
{
    public class LogController : BaseController
    {
        public ActionResult Index()
        {
            var vm = new LogsViewModel()
            {
                Files = this.DataFlowDbContext.Files.Where(x => x.Status != FileStatusEnum.DELETED).Include(x => x.Agent).Take(1000).OrderByDescending(x => x.CreateDate).ToList(),
                LogIngestions = this.DataFlowDbContext.LogIngestions.Take(1000).OrderByDescending(x => x.Date).ToList(),
                NLogs = this.DataFlowDbContext.NLogs.Take(1000).OrderByDescending(x => x.Logged).ToList()
            };

            return View(vm);
        }

        public ActionResult Retry(int id)
        {
            using (var ctx = new DataFlowDbContext())
            {
                var file = ctx.Files.Find(id);
                file.Status = FileStatusEnum.RETRY;
                file.UpdateDate = DateTime.Now;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}