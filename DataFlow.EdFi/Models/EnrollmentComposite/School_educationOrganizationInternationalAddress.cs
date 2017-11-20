namespace DataFlow.EdFi.Models.EnrollmentComposite 
{
    public class School_educationOrganizationInternationalAddress 
    {
        /// <summary>
        /// Key for Address
        /// </summary>
        public string addressType { get; set; }

        /// <summary>
        /// The first line of the address.
        /// </summary>
        public string addressLine1 { get; set; }

        /// <summary>
        /// The second line of the address.
        /// </summary>
        public string addressLine2 { get; set; }

        /// <summary>
        /// The third line of the address.
        /// </summary>
        public string addressLine3 { get; set; }

        /// <summary>
        /// The fourth line of the address.
        /// </summary>
        public string addressLine4 { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string countryDescriptor { get; set; }

        }
}

