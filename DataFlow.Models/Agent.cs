using System;
using System.Collections.Generic;

namespace DataFlow.Models
{
    public partial class Agent
    {
        public Agent()
        {
            DatamapAgent = new HashSet<DataMapAgent>();
            File = new HashSet<File>();
            LogIngestion = new HashSet<LogIngestion>();
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

        public ICollection<DataMapAgent> DatamapAgent { get; set; }
        public ICollection<File> File { get; set; }
        public ICollection<LogIngestion> LogIngestion { get; set; }
    }
}
