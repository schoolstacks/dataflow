namespace DataFlow.EdFi.Models.Resources 
{
    public class LearningObjectiveReference 
    {
        /// <summary>
        /// The designated title of the learning objective.
        /// </summary>
        public string objective { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// The grade level for which the learning objective is targeted,
        /// </summary>
        public string objectiveGradeLevelDescriptor { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related learningObjective resource.
        /// </summary>
        public Link link { get; set; }

        }
}

