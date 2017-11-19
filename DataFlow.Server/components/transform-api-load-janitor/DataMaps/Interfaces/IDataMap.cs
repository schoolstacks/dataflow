using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transform_api_load_janitor.DataMaps.Interfaces
{
    public interface IDataMap
    {
        string EntityName { get; set; }
        string ApiVersion { get; set; }
    }
}
