namespace DataFlow.EdFi.Models.Resources 
{
    public class CohortReference 
    {
        /// <summary>
        /// The name or ID for the cohort.
        /// </summary>
        public string identifier { get; set; }

        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related cohort resource.
        /// </summary>
        public Link link { get; set; }

        }
}

