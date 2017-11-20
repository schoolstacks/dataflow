using System.Collections.Generic;

namespace DataFlow.EdFi.Models.EnrollmentComposite 
{
    public class SectionEnrollment 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.
        /// </summary>
        public string uniqueSectionCode { get; set; }

        /// <summary>
        /// When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.
        /// </summary>
        public int? sequenceOfCourse { get; set; }

        /// <summary>
        /// The setting in which a child receives education and related services; for example:  Center-based instruction  Home-based instruction  Hospital class  Mainstream  Residential care and treatment facility  ....
        /// </summary>
        public string educationalEnvironmentType { get; set; }

        /// <summary>
        /// Credits or units of value awarded for the completion of a course.
        /// </summary>
        public double? availableCredits { get; set; }

        /// <summary>
        /// The intended major subject area of the course.  NEDM: Secondary Course Subject Area
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// The intended major subject area of the course.  NEDM: Secondary Course Subject Area
        /// </summary>
        public string academicSubjectType { get; set; }

        public SectionEnrollment_session sessionReference { get; set; }

        public SectionEnrollment_classPeriod classPeriodReference { get; set; }

        public SectionEnrollment_courseOffering courseOfferingReference { get; set; }

        public SectionEnrollment_location locationReference { get; set; }

        public SectionEnrollment_school schoolReference { get; set; }

        /// <summary>
        /// An unordered collection of staffSectionAssociations.  
        /// </summary>
        public List<SectionEnrollment_staffSectionAssociation> staff { get; set; }

        /// <summary>
        /// An unordered collection of studentSectionAssociations.  
        /// </summary>
        public List<SectionEnrollment_studentSectionAssociation> students { get; set; }

        }
}

