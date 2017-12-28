using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataFlow.Models
{
    public partial class FileStatus
    {
        public FileStatus()
        {
            Files = new HashSet<File>();
        }

        [Key]
        [MaxLength(255)]
        public string Value { get; set; }


        public ICollection<File> Files { get; set; }
    }
}
