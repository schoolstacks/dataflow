using System.Web.Mvc;
using DataFlow.Common.Services;
using DataFlow.Web.Services;

namespace DataFlow.Web.Helpers
{
    [Authorize]
    public class BaseController : Controller
    {
        public readonly ICentralLogger Logger;
        public readonly ICacheService CacheService;
        public readonly ConfigurationService ConfigurationService;

        private readonly IBaseServices BaseServices;

        public BaseController(IBaseServices baseServices)
        {
            this.BaseServices = baseServices;

            this.Logger = baseServices.Logger;
            this.CacheService = baseServices.CacheService;
            this.ConfigurationService = baseServices.ConfigurationService;

            ViewBag.CompanyLogo = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_COMPANY_LOGO).Value;
        }
    }
}