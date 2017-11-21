using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class MapController : BaseController
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly EdFiService edFiService;

        public MapController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
        }

        public ActionResult Index()
        {
            var maps = dataFlowDbContext.DataMaps
                .Include(x => x.Entity)
                .OrderBy(x => x.Name)
                .ToList();

            return View(maps);
        }
    }
}