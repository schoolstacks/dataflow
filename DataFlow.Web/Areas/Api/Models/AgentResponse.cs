using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Areas.Api.Models
{
    public class AgentResponse
    {
        public int agent_id { get; set; }
        public string action { get; set; }
        public string url { get; set; }
        public string loginUrl { get; set; }
        public string parameters { get; set; }

        public List<AgentScheduleResponse> schedule { get; set; }
    }
}