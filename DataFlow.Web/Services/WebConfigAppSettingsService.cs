using System;
using System.Configuration;

namespace DataFlow.Web.Services
{
    public class WebConfigAppSettingsService : IWebConfigAppSettingsService
    {
        public T GetSetting<T>(string name)
        {
            var value = ConfigurationManager.AppSettings[name];
            return (T)Convert.ChangeType(value, Type.GetTypeCode(typeof(T)));
        }

        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}