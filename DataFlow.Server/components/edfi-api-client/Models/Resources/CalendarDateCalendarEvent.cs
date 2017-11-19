using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class CalendarDateCalendarEvent 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.  
        /// </summary>
        public string calendarEventDescriptor { get; set; }

        /// <summary>
        /// The amount of time for the event as recognized by the school: 1 day = 1, 1/2 day = 0.5, 1/3 day = 0.33.
        /// </summary>
        public double? eventDuration { get; set; }

        }
}

