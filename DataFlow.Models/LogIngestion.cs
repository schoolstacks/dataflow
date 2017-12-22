using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class LogIngestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid? EducationOrganizationId { get; set; }

        [MaxLength(255)]
        public string Level { get; set; }

        [MaxLength(255)]
        public string Operation { get; set; }
        public int? AgentId { get; set; }
        public string Process { get; set; }
        public string FileName { get; set; }

        [MaxLength(255)]
        public string Result { get; set; }
        public string Message { get; set; }
        public int? RecordCount { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }
    }
}
