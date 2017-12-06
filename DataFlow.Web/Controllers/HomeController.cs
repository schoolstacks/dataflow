using System.Web.Mvc;

namespace DataFlow.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}