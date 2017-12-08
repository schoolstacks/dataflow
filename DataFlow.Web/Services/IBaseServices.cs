using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFlow.Common.Services;

namespace DataFlow.Web.Services
{
    public interface IBaseServices
    {
        ILogService LogService { get; }
        ICacheService CacheService { get; }
        IConfigurationService ConfigurationService { get; }
        IWebConfigAppSettingsService WebConfigAppSettingsService { get; }
    }
}
