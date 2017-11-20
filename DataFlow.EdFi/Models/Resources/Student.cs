using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class Student 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A unique alphanumeric code assigned to a student.
        /// </summary>
        public string studentUniqueId { get; set; }

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
        /// The set of elements that capture relevant data regarding a person's birth, including birth date and place of birth.
        /// </summary>
        public string birthCity { get; set; }

        /// <summary>
        /// The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.
        /// </summary>
        public string birthStateAbbreviationType { get; set; }

        /// <summary>
        /// For students born outside of the U.S., the date the student entered the U.S.
        /// </summary>
        public DateTime? dateEnteredUS { get; set; }

        /// <summary>
        /// Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)
        /// </summary>
        public bool? multipleBirthStatus { get; set; }

        /// <summary>
        /// ProfileThumbnail.
        /// </summary>
        public string profileThumbnail { get; set; }

        /// <summary>
        /// An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."
        /// </summary>
        public bool? hispanicLatinoEthnicity { get; set; }

        /// <summary>
        /// Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin
        /// </summary>
        public string oldEthnicityType { get; set; }

        /// <summary>
        /// An indication of inadequate financial condition of an individual's family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.
        /// </summary>
        public bool? economicDisadvantaged { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string schoolFoodServicesEligibilityDescriptor { get; set; }

        /// <summary>
        /// An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.
        /// </summary>
        public string limitedEnglishProficiencyDescriptor { get; set; }

        /// <summary>
        /// Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.
        /// </summary>
        public string displacementStatus { get; set; }

        /// <summary>
        /// The login ID for the user; used for security access control interface.
        /// </summary>
        public string loginId { get; set; }

        /// <summary>
        /// For students born outside of the US, the Province or jurisdiction in which an individual is born.
        /// </summary>
        public string birthInternationalProvince { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string citizenshipStatusType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string birthCountryDescriptor { get; set; }

        /// <summary>
        /// The student's relative preference to visual, auditory and tactile learning expressed as percentages.
        /// </summary>
        public StudentLearningStyle learningStyle { get; set; }

        /// <summary>
        /// An unordered collection of studentAddresses.  The set of elements that describes an address, including the street address, city, state, and ZIP code.
        /// </summary>
        public List<StudentAddress> addresses { get; set; }

        /// <summary>
        /// An unordered collection of studentCharacteristics.  Reflects important characteristics of the student's home situation: Displaced Homemaker, Homeless, Immigrant, Migratory, Military Parent, Pregnant Teen, Single Parent, Unaccompanied Youth.
        /// </summary>
        public List<StudentCharacteristic> characteristics { get; set; }

        /// <summary>
        /// An unordered collection of studentCohortYears.  The type and year of a cohort (e.g., 9th grade) the student belongs to as determined by the year that student entered a specific grade.
        /// </summary>
        public List<StudentCohortYear> cohortYears { get; set; }

        /// <summary>
        /// An unordered collection of studentDisabilities.  This type represents an impairment of body structure or function, a limitation in activities or a restriction in participation, as ordered by severity of impairment.
        /// </summary>
        public List<StudentDisability> disabilities { get; set; }

        /// <summary>
        /// An unordered collection of studentElectronicMails.  
        /// </summary>
        public List<StudentElectronicMail> electronicMails { get; set; }

        /// <summary>
        /// An unordered collection of studentIdentificationCodes.  A coding scheme that is used for identification and record-keeping purposes by schools, social services or other agencies to refer to a student.
        /// </summary>
        public List<StudentIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of studentIdentificationDocuments.  Represents the valid document that a person uses for identification.
        /// </summary>
        public List<StudentIdentificationDocument> identificationDocuments { get; set; }

        /// <summary>
        /// An unordered collection of studentIndicators.  An indicator or metric computed for the student (e.g., at risk) to influence more effective education or direct specific interventions.
        /// </summary>
        public List<StudentIndicator> indicators { get; set; }

        /// <summary>
        /// An unordered collection of studentInternationalAddresses.  The set of elements that describes an address, including the street address and country for international students.
        /// </summary>
        public List<StudentInternationalAddress> internationalAddresses { get; set; }

        /// <summary>
        /// An unordered collection of studentLanguages.  Language(s) the individual uses to communicate.
        /// </summary>
        public List<StudentLanguage> languages { get; set; }

        /// <summary>
        /// An unordered collection of studentOtherNames.  Other names (e.g., alias, nickname, previous legal name) associated with a person.
        /// </summary>
        public List<StudentOtherName> otherNames { get; set; }

        /// <summary>
        /// An unordered collection of studentProgramParticipations.  Key programs the student is participating in or receives services from.
        /// </summary>
        public List<StudentProgramParticipation> programParticipations { get; set; }

        /// <summary>
        /// An unordered collection of studentRaces.  The general racial category which most clearly reflects the individual's recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.
        /// </summary>
        public List<StudentRace> races { get; set; }

        /// <summary>
        /// An unordered collection of studentTelephones.  The 10-digit telephone number, including the area code, for the person.
        /// </summary>
        public List<StudentTelephone> telephones { get; set; }

        /// <summary>
        /// An unordered collection of studentVisas.  Describe the types of Visa that a non-U.S. citizen student holds.
        /// </summary>
        public List<StudentVisa> visas { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

