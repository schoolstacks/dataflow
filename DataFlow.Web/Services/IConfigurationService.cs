using System.Collections.Generic;
using DataFlow.Models;

namespace DataFlow.Web.Services
{
    public interface IConfigurationService
    {
        List<Configuration> GetConfigurationFromCache();
        Configuration GetConfigurationByKey(string key);
        void SaveConfiguration(List<Configuration> confs);

        void FillSwaggerMetadata(string apiServerUrl);

        DataFlow.Web.Models.ApiConfigurationValues GetConfiguration();
        bool AllowUserRegistrations();
    }
}
