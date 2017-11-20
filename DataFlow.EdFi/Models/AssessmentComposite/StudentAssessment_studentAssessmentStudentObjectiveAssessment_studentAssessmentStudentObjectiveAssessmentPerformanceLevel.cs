namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class StudentAssessment_studentAssessmentStudentObjectiveAssessment_studentAssessmentStudentObjectiveAssessmentPerformanceLevel 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string performanceLevelDescriptor { get; set; }

        /// <summary>
        /// Indicator of whether the student met the designated performance level.
        /// </summary>
        public bool? performanceLevelMet { get; set; }

        }
}

