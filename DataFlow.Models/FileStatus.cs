using System.Collections.Generic;

namespace DataFlow.Models
{
    public partial class FileStatus
    {
        public FileStatus()
        {
            File = new HashSet<File>();
        }

        public string Value { get; set; }

        public ICollection<File> File { get; set; }
    }
}
