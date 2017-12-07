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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a name for this agent.")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select agent type.")]
        [Display(Name = "Agent Type")]
        public string AgentTypeCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a url or connection string.")]
        public string Url { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a username.")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a directory.")]
        public string Directory { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a file pattern.")]
        [Display(Name = "File Pattern")]
        public string FilePattern { get; set; }
        public Guid Queue { get; set; }
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
