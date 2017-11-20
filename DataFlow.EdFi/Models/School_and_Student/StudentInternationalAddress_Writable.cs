using System;

namespace DataFlow.EdFi.Models.School_and_Student 
{
    public class StudentInternationalAddress_Writable 
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

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string countryDescriptor { get; set; }

        }
}

