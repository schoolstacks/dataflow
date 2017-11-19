using System;
using System.Collections.Generic;

namespace DataFlow.Models
{
    public partial class Entity
    {
        public Entity()
        {
            Bootstrapdata = new HashSet<BootstrapData>();
            Datamap = new HashSet<DataMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string Url { get; set; }
        public string Family { get; set; }
        public string Metadata { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<BootstrapData> Bootstrapdata { get; set; }
        public ICollection<DataMap> Datamap { get; set; }
    }
}
