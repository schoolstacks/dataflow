namespace DataFlow.EdFi.Models.Resources 
{
    public class AssessmentFamilyReference 
    {
        /// <summary>
        /// The title or name of the assessment family.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related assessmentFamily resource.
        /// </summary>
        public Link link { get; set; }

        }
}

