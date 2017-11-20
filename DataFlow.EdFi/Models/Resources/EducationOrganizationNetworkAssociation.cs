using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class EducationOrganizationNetworkAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related EducationOrganization resource.
        /// </summary>
        public EducationOrganizationReference memberEducationOrganizationReference { get; set; }

        /// <summary>
        /// A reference to the related EducationOrganizationNetwork resource.
        /// </summary>
        public EducationOrganizationNetworkReference educationOrganizationNetworkReference { get; set; }

        /// <summary>
        /// The date on which the EducationOrganization joined this network.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The date on which the EducationOrganization left this network.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

