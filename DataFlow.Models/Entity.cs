using System;
using System.Collections.Generic;

namespace DataFlow.Models
{
    public partial class Entity
    {
        public Entity()
        {
            BootstrapDatas = new HashSet<BootstrapData>();
            DataMaps = new HashSet<DataMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<BootstrapData> BootstrapDatas { get; set; }
        public ICollection<DataMap> DataMaps { get; set; }
    }
}
