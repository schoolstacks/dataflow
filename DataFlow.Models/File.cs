using System;

namespace DataFlow.Models
{
    public partial class File
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Url { get; set; }
        public int AgentId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public int? Rows { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Agent Agent { get; set; }
        public FileStatus StatusNavigation { get; set; }
    }
}
