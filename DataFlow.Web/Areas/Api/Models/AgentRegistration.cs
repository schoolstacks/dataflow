using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Areas.Api.Models
{
    public class AgentRegistration
    {
        public Guid uuid { get; set; }
        public Guid token { get; set; }
    }
}