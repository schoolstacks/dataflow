using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Areas.Api.Models
{
    public class AgentResponse
    {
        public int AgentId { get; set; }
        public string Action { get; set; }
        public string Url { get; set; }
        public string LoginUrl { get; set; }
        public string Parameters { get; set; }

        public List<AgentScheduleResponse> Schedule { get; set; }
    }
}