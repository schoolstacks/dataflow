using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class CalendarDateReference 
    {
        /// <summary>
        /// The identifier assigned to a school by the State Education Agency (SEA).
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// The month, day, and year of the CalendarDate.
        /// </summary>
        public DateTime? date { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related calendarDate resource.
        /// </summary>
        public Link link { get; set; }

        }
}

