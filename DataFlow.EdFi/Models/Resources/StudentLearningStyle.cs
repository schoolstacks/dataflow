namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentLearningStyle 
    {
        /// <summary>
        /// The student's relative preference expressed as a percent to visual learning.
        /// </summary>
        public double? visualLearning { get; set; }

        /// <summary>
        /// The student's relative preference expressed as a percent to auditory learning.
        /// </summary>
        public double? auditoryLearning { get; set; }

        /// <summary>
        /// The student's relative preference expressed as a percent to kinesthetic or tactile learning.
        /// </summary>
        public double? tactileLearning { get; set; }

        }
}

