using System;

namespace DataFlow.Models
{
    public partial class LogIngestion
    {
        public int Id { get; set; }
        public Guid? EducationOrganizationId { get; set; }
        public string Level { get; set; }
        public string Operation { get; set; }
        public int? AgentId { get; set; }
        public string Process { get; set; }
        public string Filename { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public int? RecordCount { get; set; }
        public DateTime Date { get; set; }

        public Agent Agent { get; set; }
    }
}
