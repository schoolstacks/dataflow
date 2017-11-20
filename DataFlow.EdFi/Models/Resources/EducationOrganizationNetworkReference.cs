namespace DataFlow.EdFi.Models.Resources 
{
    public class EducationOrganizationNetworkReference 
    {
        /// <summary>
        /// A unique number or alphanumeric code assigned to a network of education organizations.
        /// </summary>
        public int? educationOrganizationNetworkId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related educationOrganizationNetwork resource.
        /// </summary>
        public Link link { get; set; }

        }
}

