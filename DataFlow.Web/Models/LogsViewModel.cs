using System.Collections.Generic;

namespace DataFlow.Web.Models
{
    public class LogsViewModel
    {
        public List<DataFlow.Models.File> Files { get; set; }
        public List<DataFlow.Models.LogApplication> LogApplications { get; set; }
        public List<DataFlow.Models.LogIngestion> LogIngestions { get; set; }
    }
}