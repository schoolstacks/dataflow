using System;

namespace DataFlow.Models
{
    public partial class BootstrapData
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Data { get; set; }
        public int ProcessingOrder { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Entity Entity { get; set; }
    }
}
