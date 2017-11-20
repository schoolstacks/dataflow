namespace DataFlow.EdFi.Models.Resources 
{
    public class InterventionReference 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string identificationCode { get; set; }

        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related intervention resource.
        /// </summary>
        public Link link { get; set; }

        }
}

