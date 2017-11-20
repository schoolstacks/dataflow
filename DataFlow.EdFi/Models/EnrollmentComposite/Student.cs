using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.EnrollmentComposite 
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
        /// The login ID for the user; used for security access control interface.
        /// </summary>
        public string loginId { get; set; }

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
        /// An indication of inadequate financial condition of an individual's family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.
        /// </summary>
        public bool? economicDisadvantaged { get; set; }

        /// <summary>
        /// An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.
        /// </summary>
        public string limitedEnglishProficiencyDescriptor { get; set; }

        /// <summary>
        /// An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.
        /// </summary>
        public string limitedEnglishProficiencyType { get; set; }

        /// <summary>
        /// An unordered collection of studentAddresses.  
        /// </summary>
        public List<Student_studentAddress> addresses { get; set; }

        /// <summary>
        /// An unordered collection of studentCharacteristics.  
        /// </summary>
        public List<Student_studentCharacteristic> characteristics { get; set; }

        /// <summary>
        /// An unordered collection of studentCohortYears.  
        /// </summary>
        public List<Student_studentCohortYear> cohortYears { get; set; }

        /// <summary>
        /// An unordered collection of studentElectronicMails.  
        /// </summary>
        public List<Student_studentElectronicMail> electronicMails { get; set; }

        /// <summary>
        /// An unordered collection of studentIdentificationCodes.  
        /// </summary>
        public List<Student_studentIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of studentIndicators.  
        /// </summary>
        public List<Student_studentIndicator> indicators { get; set; }

        /// <summary>
        /// An unordered collection of studentLanguages.  
        /// </summary>
        public List<Student_studentLanguage> languages { get; set; }

        /// <summary>
        /// An unordered collection of studentProgramParticipations.  
        /// </summary>
        public List<Student_studentProgramParticipation> programParticipations { get; set; }

        /// <summary>
        /// An unordered collection of studentRaces.  
        /// </summary>
        public List<Student_studentRace> races { get; set; }

        /// <summary>
        /// An unordered collection of studentTelephones.  
        /// </summary>
        public List<Student_studentTelephone> telephones { get; set; }

        /// <summary>
        /// An unordered collection of studentSchoolAssociations.  
        /// </summary>
        public List<Student_studentSchoolAssociation> schoolAssociations { get; set; }

        }
}

