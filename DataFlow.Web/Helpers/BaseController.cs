using System.Web.Mvc;
using AutoMapper;
using DataFlow.Common.Services;
using DataFlow.Web.Services;
using NLog;

namespace DataFlow.Web.Helpers
{
    [Authorize]
    public class BaseController : Controller
    {
        public readonly ILogService LogService;
        public readonly ICacheService CacheService;
        public readonly IConfigurationService ConfigurationService;
        public readonly IWebConfigAppSettingsService WebConfigAppSettingsService;
        public readonly IMapper MapperService;

        public BaseController(IBaseServices baseServices)
        {
            this.LogService = baseServices.LogService;
            this.CacheService = baseServices.CacheService;
            this.ConfigurationService = baseServices.ConfigurationService;
            this.WebConfigAppSettingsService = baseServices.WebConfigAppSettingsService;
            this.MapperService = baseServices.MapperService;

            if (LogService != null)
                this.LogService.Name = GetType().FullName;

            ViewBag.OrganizationLogo = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_ORGANIZATION_LOGO).Value;
            ViewBag.OrganizationUrl = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_ORGANIZATION_URL).Value;
            ViewBag.EducationText = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_EDU_USE_TEXT).Value;
        }
    }
}