using System;
using System.Collections.Generic;

namespace DataFlow.Models
{
    public partial class DataMap
    {
        public DataMap()
        {
            DataMapAgents = new HashSet<DataMapAgent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int EntityId { get; set; }
        public string Map { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Entity Entity { get; set; }
        public ICollection<DataMapAgent> DataMapAgents { get; set; }
    }
}
