using System;

namespace DataFlow.EdFi.Models.School_and_Student 
{
    public class EducationOrganizationAddress_School_Readable 
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
        /// The apartment, room, or suite number of an address.
        /// </summary>
        public string apartmentRoomSuiteNumber { get; set; }

        /// <summary>
        /// The number of the building on the site, if more than one building shares the same address.
        /// </summary>
        public string buildingSiteNumber { get; set; }

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

        /// <summary>
        /// Definition The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.
        /// </summary>
        public string countyFIPSCode { get; set; }

        /// <summary>
        /// The geographic latitude of the physical address.
        /// </summary>
        public string latitude { get; set; }

        /// <summary>
        /// The geographic longitude of the physical address.
        /// </summary>
        public string longitude { get; set; }

        /// <summary>
        /// The first date the address is valid. For physical addresses, the date the person moved to that address.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The last date the address is valid. For physical addresses, this would be the date the person moved from that address.
        /// </summary>
        public DateTime? endDate { get; set; }

        }
}

