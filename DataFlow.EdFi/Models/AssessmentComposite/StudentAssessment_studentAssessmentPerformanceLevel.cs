namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class StudentAssessment_studentAssessmentPerformanceLevel 
    {
        /// <summary>
        /// The ID of the Performance Level Descriptor
        /// </summary>
        public string performanceLevelDescriptor { get; set; }

        /// <summary>
        /// Optional indicator of whether the performance level was met.
        /// </summary>
        public bool? performanceLevelMet { get; set; }

        }
}

