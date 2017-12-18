using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlow.Server.TransformLoad.DataMaps.Interfaces
{
    public interface IDataMap
    {
        string EntityName { get; set; }
        string ApiVersion { get; set; }
    }
}
