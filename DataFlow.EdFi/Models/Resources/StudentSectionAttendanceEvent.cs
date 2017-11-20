using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentSectionAttendanceEvent 
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
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// Date for this attendance event.
        /// </summary>
        public DateTime? eventDate { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string attendanceEventCategoryDescriptor { get; set; }

        /// <summary>
        /// The reason for the absence or tardy.
        /// </summary>
        public string attendanceEventReason { get; set; }

        /// <summary>
        /// The setting in which a child receives education and related services.  This is only used in the AttendanceEvent if different from that in the related Section.
        /// </summary>
        public string educationalEnvironmentType { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

