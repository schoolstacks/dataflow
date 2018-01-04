using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Areas.Api.Models
{
    public class AgentScheduleResponse
    {
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public AgentScheduleResponse(int day, int hour, int minute)
        {
            this.Day = day;
            this.Hour = hour;
            this.Minute = minute;
        }
    }
}