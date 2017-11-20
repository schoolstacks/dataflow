using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class CalendarDate 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

        /// <summary>
        /// The month, day, and year of the CalendarDate.
        /// </summary>
        public DateTime? date { get; set; }

        /// <summary>
        /// An unordered collection of calendarDateCalendarEvents.  
        /// </summary>
        public List<CalendarDateCalendarEvent> calendarEvents { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

