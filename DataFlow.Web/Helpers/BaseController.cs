using System.Web.Mvc;
using DataFlow.Common.Services;
using DataFlow.Web.Services;

namespace DataFlow.Web.Helpers
{
    [Authorize]
    public class BaseController : Controller
    {
        public readonly ILogService LogService;
        public readonly ICacheService CacheService;
        public readonly IConfigurationService ConfigurationService;
        public readonly IWebConfigAppSettingsService WebConfigAppSettingsService;

        private readonly IBaseServices BaseServices;

        public BaseController(IBaseServices baseServices)
        {
            this.BaseServices = baseServices;

            this.LogService = baseServices.LogService;
            this.CacheService = baseServices.CacheService;
            this.ConfigurationService = baseServices.ConfigurationService;
            this.WebConfigAppSettingsService = baseServices.WebConfigAppSettingsService;

            ViewBag.CompanyLogo = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_COMPANY_LOGO).Value;
            ViewBag.CompanyUrl = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_COMPANY_URL).Value;
            ViewBag.EducationText = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_EDU_USE_TEXT).Value;
        }
    }
}