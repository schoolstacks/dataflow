using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.EnrollmentComposite 
{
    public class SectionEnrollment_session 
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// The identifier for the school year (e.g., 2010/11).
        /// </summary>
        public int? schoolYear { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string termDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string termType { get; set; }

        /// <summary>
        /// The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).  NEDM: Session Type
        /// </summary>
        public string sessionName { get; set; }

        /// <summary>
        /// Month, day, and year of the first day of the Session.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// Month, day, and year of the last day of the Session.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The total number of instructional days in the school calendar.
        /// </summary>
        public int? totalInstructionalDays { get; set; }

        }
}

