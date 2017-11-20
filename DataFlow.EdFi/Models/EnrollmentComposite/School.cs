using System.Collections.Generic;

namespace DataFlow.EdFi.Models.EnrollmentComposite 
{
    public class School 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The identifier assigned to a school by the State Education Agency (SEA).
        /// </summary>
        public int? schoolId { get; set; }

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
        /// The instructional categorization of the school (e.g., Regular, Alternative)
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.
        /// </summary>
        public string charterStatusType { get; set; }

        /// <summary>
        /// Denotes the Title I Part A designation for the school.
        /// </summary>
        public string titleIPartASchoolDesignationType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string administrativeFundingControlDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string administrativeFundingControlType { get; set; }

        public School_localEducationAgency localEducationAgencyReference { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationAddresses.  
        /// </summary>
        public List<School_educationOrganizationAddress> addresses { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationCategories.  
        /// </summary>
        public List<School_educationOrganizationCategory> educationOrganizationCategories { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationIdentificationCodes.  
        /// </summary>
        public List<School_educationOrganizationIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationInstitutionTelephones.  
        /// </summary>
        public List<School_educationOrganizationInstitutionTelephone> institutionTelephones { get; set; }

        /// <summary>
        /// An unordered collection of educationOrganizationInternationalAddresses.  
        /// </summary>
        public List<School_educationOrganizationInternationalAddress> internationalAddresses { get; set; }

        /// <summary>
        /// An unordered collection of schoolCategories.  
        /// </summary>
        public List<School_schoolCategory> schoolCategories { get; set; }

        /// <summary>
        /// An unordered collection of schoolGradeLevels.  
        /// </summary>
        public List<School_schoolGradeLevel> gradeLevels { get; set; }

        }
}

