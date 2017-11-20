using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class School 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related LocalEducationAgency resource.
        /// </summary>
        public LocalEducationAgencyReference localEducationAgencyReference { get; set; }

        /// <summary>
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference charterApprovalSchoolYearTypeReference { get; set; }

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
        /// A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2)to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).
        /// </summary>
        public string magnetSpecialProgramEmphasisSchoolType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string administrativeFundingControlDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string internetAccessType { get; set; }

        /// <summary>
        /// Key for MagnetSpecialProgramEmphasisSchool
        /// </summary>
        public string charterApprovalAgencyType { get; set; }

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
        /// An unordered collection of schoolCategories.  The category of school. (e.g., High School, Middle School or Elementary School).
        /// </summary>
        public List<SchoolCategory> schoolCategories { get; set; }

        /// <summary>
        /// An unordered collection of schoolGradeLevels.  The grade levels served at the school.
        /// </summary>
        public List<SchoolGradeLevel> gradeLevels { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

