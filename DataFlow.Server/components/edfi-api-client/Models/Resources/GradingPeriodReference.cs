using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class GradingPeriodReference 
    {
        /// <summary>
        /// The name of the grading period during the school year in which the grade is offered (e.g., 1st cycle, 1st semester)
        /// </summary>
        public string descriptor { get; set; }

        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// Month, day, and year of the first day of the GradingPeriod.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related gradingPeriod resource.
        /// </summary>
        public Link link { get; set; }

        }
}

