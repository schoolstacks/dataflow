using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class Section 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related ClassPeriod resource.
        /// </summary>
        public ClassPeriodReference classPeriodReference { get; set; }

        /// <summary>
        /// A reference to the related CourseOffering resource.
        /// </summary>
        public CourseOfferingReference courseOfferingReference { get; set; }

        /// <summary>
        /// A reference to the related Location resource.
        /// </summary>
        public LocationReference locationReference { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

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
        /// The media through which teachers provide instruction to students and students and teachers communicate about instructional matters; for example:  Technology-based instruction in classroom  Correspondence instruction  Face-to-face instruction  Virtual/On-line Distance learning  Center-based instruction  ...
        /// </summary>
        public string mediumOfInstructionType { get; set; }

        /// <summary>
        /// The population for which the course was designed; for example:  Bilingual students  Remedial education students  Gifted and talented students  Career and Technical Education students  Special education students  ....
        /// </summary>
        public string populationServedType { get; set; }

        /// <summary>
        /// The type of credits or units of value awarded for the completion of a course.
        /// </summary>
        public string availableCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? availableCreditConversion { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string instructionLanguageDescriptor { get; set; }

        /// <summary>
        /// Credits or units of value awarded for the completion of a course.
        /// </summary>
        public double? availableCredits { get; set; }

        /// <summary>
        /// An unordered collection of sectionCharacteristics.  Reflects important characteristics of the Section, such as whether or not attendance is taken and the Section is graded.
        /// </summary>
        public List<SectionCharacteristic> characteristics { get; set; }

        /// <summary>
        /// An unordered collection of sectionPrograms.  Optional reference to program (e.g., CTE) to which the section is associated.
        /// </summary>
        public List<SectionProgram> programs { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

