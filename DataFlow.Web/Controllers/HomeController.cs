using System.Web.Mvc;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IBaseServices baseService) : base(baseService)
        {
            
        }

        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}