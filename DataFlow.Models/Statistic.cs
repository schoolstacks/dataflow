using System;

namespace DataFlow.Models
{
    public partial class Statistic
    {
        public int Id { get; set; }
        public Guid EntityId { get; set; }
        public string EntityType { get; set; }
        public int? TermDescriptorId { get; set; }
        public short? SchoolYear { get; set; }
        public string Measure { get; set; }
        public int? ValueInt { get; set; }
        public decimal? ValueDecimal { get; set; }
        public string ValueVarchar { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
