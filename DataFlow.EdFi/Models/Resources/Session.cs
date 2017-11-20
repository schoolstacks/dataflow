using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class Session 
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
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference schoolYearTypeReference { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string termDescriptor { get; set; }

        /// <summary>
        /// The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).  NEDM: Session Type
        /// </summary>
        public string name { get; set; }

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

        /// <summary>
        /// An unordered collection of sessionAcademicWeeks.  
        /// </summary>
        public List<SessionAcademicWeek> academicWeeks { get; set; }

        /// <summary>
        /// An unordered collection of sessionGradingPeriods.  Grading periods associated with the session calendar.
        /// </summary>
        public List<SessionGradingPeriod> gradingPeriods { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

