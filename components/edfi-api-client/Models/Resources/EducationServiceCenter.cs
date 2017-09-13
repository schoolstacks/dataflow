using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class EducationServiceCenter 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related StateEducationAgency resource.
        /// </summary>
        public StateEducationAgencyReference stateEducationAgencyReference { get; set; }

        /// <summary>
        /// The identifier assigned to an education service center by the State Education Agency (SEA).
        /// </summary>
        public int? educationServiceCenterId { get; set; }

        /// <summary>
        /// The identifier assigned to an education agency by the State Education Agency (SEA).  Also known as the State LEP ID.  NEDM: IdentificationCode, LEA Identifier (State)
        /// </summary>
        public string stateOrganizationId { get; set; }

        /// <summary>
        /// The full, legally accepted name of the institution.  NEDM: Name of Institution
        /// </summary>
        public string nameOfInstitution { get; set; }

        /// <summary>
        /// A short name for the institution.
        /// </summary>
        public string shortNameOfInstitution { get; set; }

        /// <summary>
        /// The public web site address (URL) for the educational organization.
        /// </summary>
        public string webSite { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string operationalStatusType { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationAddresses.  The set of elements that describes an address, including the street address, city, state and ZIP code.
        /// </summary>
        public List<EducationOrganizationAddress> addresses { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationCategories.  The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.
        /// </summary>
        public List<EducationOrganizationCategory> educationOrganizationCategories { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationIdentificationCodes.  A unique number or alphanumeric code that is assigned to an education organization by a school, school system, state, or other agency or entity.
        /// </summary>
        public List<EducationOrganizationIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationInstitutionTelephones.  The 10-digit telephone number, including the area code, for the person.
        /// </summary>
        public List<EducationOrganizationInstitutionTelephone> institutionTelephones { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationInternationalAddresses.  The set of elements that describes an address, including the street address and country for international students.
        /// </summary>
        public List<EducationOrganizationInternationalAddress> internationalAddresses { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

