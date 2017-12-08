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
        ICentralLogger Logger { get; }
        ICacheService CacheService { get; }
        ConfigurationService ConfigurationService { get; }
    }
}
