using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class DataMapAgent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DataMapId { get; set; }
        public int AgentId { get; set; }
        public int ProcessingOrder { get; set; }

        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }
        [ForeignKey("DataMapId")]
        public DataMap DataMap { get; set; }
    }
}
