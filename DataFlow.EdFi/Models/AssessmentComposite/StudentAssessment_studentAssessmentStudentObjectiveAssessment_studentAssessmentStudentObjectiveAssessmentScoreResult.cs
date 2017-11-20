namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class StudentAssessment_studentAssessmentStudentObjectiveAssessment_studentAssessmentStudentObjectiveAssessmentScoreResult 
    {
        /// <summary>
        /// Key for AssessmentReportingMethod
        /// </summary>
        public string assessmentReportingMethodType { get; set; }

        /// <summary>
        /// The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string resultDatatypeType { get; set; }

        }
}

