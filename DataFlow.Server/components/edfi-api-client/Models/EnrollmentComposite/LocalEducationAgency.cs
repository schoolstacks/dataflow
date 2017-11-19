using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.EnrollmentComposite 
{
    public class LocalEducationAgency 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The identifier assigned to a local education agency by the State Education Agency (SEA).
        /// </summary>
        public int? localEducationAgencyId { get; set; }

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
        /// Key for LEACategory
        /// </summary>
        public string categoryType { get; set; }

        /// <summary>
        /// Key for CharterStatus
        /// </summary>
        public string charterStatusType { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationAddresses.  
        /// </summary>
        public List<LocalEducationAgency_educationOrganizationAddress> addresses { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationCategories.  
        /// </summary>
        public List<LocalEducationAgency_educationOrganizationCategory> educationOrganizationCategories { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationIdentificationCodes.  
        /// </summary>
        public List<LocalEducationAgency_educationOrganizationIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationInstitutionTelephones.  
        /// </summary>
        public List<LocalEducationAgency_educationOrganizationInstitutionTelephone> institutionTelephones { get; set; }

        }
}

