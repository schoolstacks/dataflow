using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class InterventionMeetingTime 
    {
        /// <summary>
        /// A reference to the related ClassPeriod resource.
        /// </summary>
        public ClassPeriodReference classPeriodReference { get; set; }

        /// <summary>
        /// used for the bell schedule, another name for day (e.g., Blue day, Red day).
        /// </summary>
        public string alternateDayName { get; set; }

        /// <summary>
        /// An indication of the time of day the class begins.
        /// </summary>
        public string startTime { get; set; }

        /// <summary>
        /// An indication of the time of day the class ends.
        /// </summary>
        public string endTime { get; set; }

        /// <summary>
        /// Indicator of whether this meeting time is used for official daily attendance.
        /// </summary>
        public bool? officialAttendancePeriod { get; set; }

        }
}

