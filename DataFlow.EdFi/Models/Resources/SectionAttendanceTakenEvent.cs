using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class SectionAttendanceTakenEvent 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Section resource.
        /// </summary>
        public SectionReference sectionReference { get; set; }

        /// <summary>
        /// A reference to the related CalendarDate resource.
        /// </summary>
        public CalendarDateReference calendarDateReference { get; set; }

        /// <summary>
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// The date the SectionAttendanceTakenEvent was submitted, which could be a different date than the instructional day.
        /// </summary>
        public DateTime? eventDate { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

