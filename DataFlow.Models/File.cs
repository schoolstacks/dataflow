using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class File
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }
        public string Url { get; set; }
        public int AgentId { get; set; }

        [Required, MaxLength(255)]
        public string Status { get; set; }
        public string Message { get; set; }
        public int? Rows { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }

        [ForeignKey("Status")]
        public FileStatus StatusNavigation { get; set; }
    }
}
