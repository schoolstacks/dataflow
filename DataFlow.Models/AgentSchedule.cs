using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class AgentSchedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }
    }
}
