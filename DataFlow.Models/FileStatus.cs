using System.Collections.Generic;

namespace DataFlow.Models
{
    public partial class FileStatus
    {
        public FileStatus()
        {
            Files = new HashSet<File>();
        }

        public string Value { get; set; }

        public ICollection<File> Files { get; set; }
    }
}
