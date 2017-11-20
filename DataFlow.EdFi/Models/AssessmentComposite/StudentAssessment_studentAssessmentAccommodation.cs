namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class StudentAssessment_studentAssessmentAccommodation 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string accommodationDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string accommodationType { get; set; }

        }
}

