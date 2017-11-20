using System;

namespace DataFlow.EdFi.Models.School_and_Student 
{
    public class StudentIndicator_Writable 
    {
        /// <summary>
        /// The name of the Indicator, indicator group, or metric computed for the student (e.g., at risk) to influence more effective education or direct specific interventions.
        /// </summary>
        public string indicatorName { get; set; }

        /// <summary>
        /// Indicator or metric computed for the student (e.g., at risk) to influence more effective education or direct specific interventions.
        /// </summary>
        public string indicator { get; set; }

        /// <summary>
        /// The name for a group of indicators.
        /// </summary>
        public string indicatorGroup { get; set; }

        /// <summary>
        /// The date when the indicator was assigned or computed.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The date the indicator or metric was sunset or removed.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The person, organization, or department that made a student designation.
        /// </summary>
        public string designatedBy { get; set; }

        }
}

