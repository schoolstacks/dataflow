using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class GradingPeriod 
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
        /// The name of the grading period during the school year in which the grade is offered (e.g., 1st cycle, 1st semester)
        /// </summary>
        public string descriptor { get; set; }

        /// <summary>
        /// Month, day, and year of the first day of the GradingPeriod.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// Total days available for educational instruction during the grading period.
        /// </summary>
        public int? totalInstructionalDays { get; set; }

        /// <summary>
        /// Month, day, and year of the last day of the GradingPeriod.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The sequential order of this period relative to other periods.
        /// </summary>
        public int? periodSequence { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

