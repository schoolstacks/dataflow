using DataFlow.Common.Services;

namespace DataFlow.Web.Services
{
    public class BaseServices : IBaseServices
    {
        public ICentralLogger Logger { get; }
        public ICacheService CacheService { get; }
        public IConfigurationService ConfigurationService { get; }
    }
}