using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFlow.Models;

namespace DataFlow.Server.ReportingCleanup
{
    public class EmailMessage
    {
        public string EmailDate { get; set; }
        public List<File> Files { get; set; }
        public List<File> DeletedFiles { get; set; }

        public int DeleteDays { get; set; }
    }
}
