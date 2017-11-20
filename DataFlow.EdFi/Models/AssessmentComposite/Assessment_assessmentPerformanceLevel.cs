namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class Assessment_assessmentPerformanceLevel 
    {
        /// <summary>
        /// The minimum score required to make the indicated level of performance.
        /// </summary>
        public string minimumScore { get; set; }

        /// <summary>
        /// The maximum score to make the indicated level of performance.
        /// </summary>
        public string maximumScore { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string resultDatatypeType { get; set; }

        }
}

