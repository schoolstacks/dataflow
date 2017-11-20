namespace DataFlow.EdFi.Models.Resources 
{
    public class AssessmentScore 
    {
        /// <summary>
        /// Key for AssessmentReportingMethod
        /// </summary>
        public string assessmentReportingMethodType { get; set; }

        /// <summary>
        /// The minimum score possible on the assessment.
        /// </summary>
        public string minimumScore { get; set; }

        /// <summary>
        /// The maximum score possible on the assessment.
        /// </summary>
        public string maximumScore { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string resultDatatypeType { get; set; }

        }
}

