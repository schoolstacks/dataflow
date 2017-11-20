namespace DataFlow.EdFi.Models.Resources 
{
    public class CourseTranscriptEarnedAdditionalCredits 
    {
        /// <summary>
        /// The type of credits awarded or earned for the course.
        /// </summary>
        public string additionalCreditType { get; set; }

        /// <summary>
        /// The number of credits awarded or earned for the course.
        /// </summary>
        public double? credits { get; set; }

        }
}

