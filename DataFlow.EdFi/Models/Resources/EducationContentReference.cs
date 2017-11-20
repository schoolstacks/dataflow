namespace DataFlow.EdFi.Models.Resources 
{
    public class EducationContentReference 
    {
        /// <summary>
        /// The identifier of the content standard.
        /// </summary>
        public string contentIdentifier { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related educationContent resource.
        /// </summary>
        public Link link { get; set; }

        }
}

