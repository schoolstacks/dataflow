using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataFlow.Common.DAL;
using DataFlow.Common.Services;
using DataFlow.Models;
using DataFlow.Web.Helpers;
using Newtonsoft.Json;
using System.Net;

namespace DataFlow.Web.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly ICacheService cacheService;

        public ConfigurationService(DataFlowDbContext dataFlowDbContext, ICacheService cacheService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.cacheService = cacheService;
        }

        public List<Configuration> GetConfigurationFromCache()
        {
            if (!cacheService.Exists(Constants.ConfigurationCacheKey))
            {
                var conf = dataFlowDbContext.Configurations.ToList();
                cacheService.Add(Constants.ConfigurationCacheKey, JsonConvert.SerializeObject(conf));
            }
            var cacheValue =  cacheService.Get(Constants.ConfigurationCacheKey);
            return JsonConvert.DeserializeObject<List<Configuration>>(cacheValue);
        }

        public Configuration GetConfigurationByKey(string key)
        {
            return GetConfigurationFromCache().FirstOrDefault(a => a.Key == key) ?? new Configuration() {Key = key};
        }

        public bool AllowUserRegistrations()
        {
            var configValue = GetConfigurationByKey(Constants.INSTANCE_ALLOW_USER_REGISTRATION).Value;

            return string.IsNullOrWhiteSpace(configValue) || Convert.ToBoolean(configValue);
        }

        public void SaveConfiguration(List<Configuration> confs)
        {
            dataFlowDbContext.Configurations.AddOrUpdate(confs.ToArray());
            dataFlowDbContext.SaveChanges();

            cacheService.AddOrUpdate(Constants.ConfigurationCacheKey, JsonConvert.SerializeObject(confs));
        }

        public DataFlow.Web.Models.ApiConfigurationValues GetConfiguration()
        {
            var conf = new DataFlow.Web.Models.ApiConfigurationValues
            {
                API_SERVER_URL = GetConfigurationByKey(Constants.API_SERVER_URL).Value,
                API_SERVER_KEY = GetConfigurationByKey(Constants.API_SERVER_KEY).Value,
                API_SERVER_SECRET = GetConfigurationByKey(Constants.API_SERVER_SECRET).Value,
                INSTANCE_COMPANY_LOGO = GetConfigurationByKey(Constants.INSTANCE_COMPANY_LOGO).Value,
                INSTANCE_COMPANY_URL = GetConfigurationByKey(Constants.INSTANCE_COMPANY_URL).Value,
                INSTANCE_EDU_USE_TEXT = GetConfigurationByKey(Constants.INSTANCE_EDU_USE_TEXT).Value,
                INSTANCE_ALLOW_USER_REGISTRATION = Convert.ToBoolean(GetConfigurationByKey(Constants.INSTANCE_ALLOW_USER_REGISTRATION).Value)
            };
            
            return conf;
        }

        public void FillSwaggerMetadata(string apiServerUrl)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderLocal, certificate, chain, sslPolicyErrors) => true;

            using (DataFlowDbContext ctx = new DataFlowDbContext())
            {
                WebClient client = new WebClient();
                string baseUrl = Common.Helpers.UrlUtility.GetUntilOrEmpty(apiServerUrl.Trim(), "/api/");

                foreach (Entity entity in ctx.Entities)
                {
                    string url = baseUrl + entity.Url;
                    string metadata = client.DownloadString(url);
                    entity.Metadata = metadata;
                }
                ctx.SaveChanges();
            }
        }
    }
}