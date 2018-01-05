using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Areas.Api.Models
{
    public class AgentScheduleResponse
    {
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }

        public AgentScheduleResponse(int day, int hour, int minute)
        {
            this.day = day;
            this.hour = hour;
            this.minute = minute;
        }
    }
}