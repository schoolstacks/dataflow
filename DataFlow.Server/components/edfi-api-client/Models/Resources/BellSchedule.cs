using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class BellSchedule 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related CalendarDate resource.
        /// </summary>
        public CalendarDateReference calendarDateReference { get; set; }

        /// <summary>
        /// Name or title of the bell schedule.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string gradeLevelDescriptor { get; set; }

        /// <summary>
        /// An unordered collection of bellScheduleMeetingTimes.  
        /// </summary>
        public List<BellScheduleMeetingTime> meetingTimes { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

