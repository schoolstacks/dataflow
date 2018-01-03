using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class AgentAgentChrome
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AgentId { get; set; }
        public int AgentChromeId { get; set; }

        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }
        [ForeignKey("AgentChromeId")]
        public AgentChrome AgentChrome { get; set; }
    }
}
