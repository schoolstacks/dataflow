using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class Staff 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A unique alphanumeric code assigned to a staff.
        /// </summary>
        public string staffUniqueId { get; set; }

        /// <summary>
        /// A prefix used to denote the title, degree, position, or seniority of the person.
        /// </summary>
        public string personalTitlePrefix { get; set; }

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// A secondary name given to an individual at birth, baptism, or during another naming ceremony.
        /// </summary>
        public string middleName { get; set; }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        public string lastSurname { get; set; }

        /// <summary>
        /// An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).
        /// </summary>
        public string generationCodeSuffix { get; set; }

        /// <summary>
        /// The person's maiden name.
        /// </summary>
        public string maidenName { get; set; }

        /// <summary>
        /// A person''s gender.
        /// </summary>
        public string sexType { get; set; }

        /// <summary>
        /// The month, day, and year on which an individual was born.
        /// </summary>
        public DateTime? birthDate { get; set; }

        /// <summary>
        /// An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."
        /// </summary>
        public bool? hispanicLatinoEthnicity { get; set; }

        /// <summary>
        /// Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin
        /// </summary>
        public string oldEthnicityType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string highestCompletedLevelOfEducationDescriptor { get; set; }

        /// <summary>
        /// The total number of years that an individual has previously held a similar professional position in one or more education institutions.
        /// </summary>
        public double? yearsOfPriorProfessionalExperience { get; set; }

        /// <summary>
        /// The total number of years that an individual has previously held a teaching position in one or more education institutions.
        /// </summary>
        public double? yearsOfPriorTeachingExperience { get; set; }

        /// <summary>
        /// An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.
        /// </summary>
        public bool? highlyQualifiedTeacher { get; set; }

        /// <summary>
        /// The login ID for the user; used for security access control interface.
        /// </summary>
        public string loginId { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string citizenshipStatusType { get; set; }

        /// <summary>
        /// An unordered collection of staffAddresses.  The set of elements that describes an address, including the street address, city, state and ZIP code.
        /// </summary>
        public List<StaffAddress> addresses { get; set; }

        /// <summary>
        /// An unordered collection of staffCredentials.  The legal document giving authorization to perform teaching assignment services.
        /// </summary>
        public List<StaffCredential> credentials { get; set; }

        /// <summary>
        /// An unordered collection of staffElectronicMails.  The numbers, letters and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.
        /// </summary>
        public List<StaffElectronicMail> electronicMails { get; set; }

        /// <summary>
        /// An unordered collection of staffIdentificationCodes.  A coding scheme that is used for identification and record-keeping purposes by schools, social services or other agencies to refer to a staff member.
        /// </summary>
        public List<StaffIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of staffIdentificationDocuments.  Represents the valid document that a person uses for identification.
        /// </summary>
        public List<StaffIdentificationDocument> identificationDocuments { get; set; }

        /// <summary>
        /// An unordered collection of staffInternationalAddresses.  The set of elements that describes an address, including the street address, city, state and ZIP code.
        /// </summary>
        public List<StaffInternationalAddress> internationalAddresses { get; set; }

        /// <summary>
        /// An unordered collection of staffLanguages.  Language(s) the individual uses to communicate.
        /// </summary>
        public List<StaffLanguage> languages { get; set; }

        /// <summary>
        /// An unordered collection of staffOtherNames.  Other names (e.g., alias, nickname, previous legal name) associated with a person.
        /// </summary>
        public List<StaffOtherName> otherNames { get; set; }

        /// <summary>
        /// An unordered collection of staffRaces.  The general racial category which most clearly reflects the individual's recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.
        /// </summary>
        public List<StaffRace> races { get; set; }

        /// <summary>
        /// An unordered collection of staffTelephones.  The 10-digit telephone number, including the area code, for the person.
        /// </summary>
        public List<StaffTelephone> telephones { get; set; }

        /// <summary>
        /// An unordered collection of staffVisas.  Describe the types of visa that a non-U.S. citizen staff member holds.
        /// </summary>
        public List<StaffVisa> visas { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

