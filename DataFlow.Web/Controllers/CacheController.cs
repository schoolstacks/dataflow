using System.Web.Mvc;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class CacheController : BaseController
    {
        public CacheController(IBaseServices baseServices) : base(baseServices)
        {
        }

        public ActionResult Index()
        {
            ViewBag.CacheStats = CacheService.GetStats();

            return View();
        }

        public ActionResult Clear()
        {
            CacheService.Clear();

            return RedirectToAction("Index");
        }
    }
}