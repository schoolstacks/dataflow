namespace DataFlow.EdFi.Models.EnrollmentComposite 
{
    public class LocalEducationAgency_educationOrganizationAddress 
    {
        /// <summary>
        /// Key for Address
        /// </summary>
        public string addressType { get; set; }

        /// <summary>
        /// The street number and street name or post office box number of an address.
        /// </summary>
        public string streetNumberName { get; set; }

        /// <summary>
        /// The name of the city in which an address is located.
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// The abbreviation for the state (within the United States) or outlying area in which an address is located.
        /// </summary>
        public string stateAbbreviationType { get; set; }

        /// <summary>
        /// The five or nine digit zip code or overseas postal code portion of an address.
        /// </summary>
        public string postalCode { get; set; }

        /// <summary>
        /// The name of the county, parish, borough, or comparable unit (within a state) in which an address is located.
        /// </summary>
        public string nameOfCounty { get; set; }

        }
}

