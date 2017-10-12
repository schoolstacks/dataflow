using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_components_data_access.Dataflow
{
    public partial class DataFlowContext: DbContext
    {
        public DataFlowContext(EntityConnection entityConnection):base(entityConnection,true)
        {

        }
    }
}
