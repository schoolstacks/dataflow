using System;
using System.Collections.Generic;

namespace DataFlow.Models
{
    public partial class Agent
    {
        public Agent()
        {
            DataMapAgents = new HashSet<DataMapAgent>();
            Files = new HashSet<File>();
            LogIngestions = new HashSet<LogIngestion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AgentTypeCode { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Directory { get; set; }
        public string FilePattern { get; set; }
        public Guid Queue { get; set; }
        public string Custom { get; set; }
        public bool Enabled { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastExecuted { get; set; }

        public ICollection<DataMapAgent> DataMapAgents { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<LogIngestion> LogIngestions { get; set; }
    }
}
