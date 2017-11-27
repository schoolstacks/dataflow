using System.Web.Mvc;
using DataFlow.Common.Services;

namespace DataFlow.Web.Helpers
{
    [Authorize]
    public class BaseController : Controller
    {
        public readonly ICentralLogger Logger;

        public BaseController(ICentralLogger logger)
        {
            this.Logger = logger;
        }
    }
}