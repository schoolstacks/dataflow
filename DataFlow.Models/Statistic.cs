using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class Statistic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid EntityId { get; set; }
        [Required, MaxLength(255)]
        public string EntityType { get; set; }
        public int? TermDescriptorId { get; set; }
        public short? SchoolYear { get; set; }
        [Required, MaxLength(255)]
        public string Measure { get; set; }
        public int? ValueInt { get; set; }
        public decimal? ValueDecimal { get; set; }
        public string ValueVarchar { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
