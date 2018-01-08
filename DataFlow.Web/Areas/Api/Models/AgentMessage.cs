using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Areas.Api.Models
{
    public class AgentMessage
    {
        public Guid uuid { get; set; }
        public Guid token { get; set; }
        public int agent_id { get; set; }
        public string filename { get; set; }
        public string data { get; set; }
        public string message { get; set; }
    }
}