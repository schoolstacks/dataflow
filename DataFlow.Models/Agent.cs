using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class Agent
    {
        public Agent()
        {
            DataMapAgents = new HashSet<DataMapAgent>();
            AgentSchedules = new HashSet<AgentSchedule>();
            Files = new HashSet<File>();
            LogIngestions = new HashSet<LogIngestion>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Agent Type")]
        [MaxLength(50)]
        public string AgentTypeCode { get; set; }
        
        [Display(Name = "Agent Action")]
        [MaxLength(50)]
        public string AgentAction { get; set; }

        public string Url { get; set; }

        public string LoginUrl { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Directory { get; set; }

        [Display(Name = "File Pattern")]
        public string FilePattern { get; set; }

        public Guid Queue { get; set; }

        [Display(Name = "Custom Parameters")]
        public string Custom { get; set; }

        public bool Enabled { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastExecuted { get; set; }

        public ICollection<DataMapAgent> DataMapAgents { get; set; }
        public ICollection<AgentSchedule> AgentSchedules { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<LogIngestion> LogIngestions { get; set; }
    }
}
