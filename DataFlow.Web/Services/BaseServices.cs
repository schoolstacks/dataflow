using DataFlow.Common.Services;

namespace DataFlow.Web.Services
{
    public class BaseServices : IBaseServices
    {
        public ILogService LogService { get; }
        public ICacheService CacheService { get; }
        public IConfigurationService ConfigurationService { get; }
        public IWebConfigAppSettingsService WebConfigAppSettingsService { get; }
    }
}