using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class Course 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related EducationOrganization resource.
        /// </summary>
        public EducationOrganizationReference educationOrganizationReference { get; set; }

        /// <summary>
        /// TThe actual code that identifies the organization of subject matter and related learning experiences provided for the instruction of students.
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, and language arts).
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The number of parts identified for a course.
        /// </summary>
        public int? numberOfParts { get; set; }

        /// <summary>
        /// The intended major subject area of the course.  NEDM: Secondary Course Subject Area
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// A description of the content standards and goals covered in the course. Reference may be made to state or national content standards.  NEDM: Course Description
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Date the course was adopted by the education agency.
        /// </summary>
        public DateTime? dateCourseAdopted { get; set; }

        /// <summary>
        /// An indication that this course may satisfy high school graduation requirements in the course's subject area.
        /// </summary>
        public bool? highSchoolCourseRequirement { get; set; }

        /// <summary>
        /// An indicator of whether or not this course being described is included in the computation of the student's Grade Point Average, and if so, if it weighted differently from regular courses.
        /// </summary>
        public string gpaApplicabilityType { get; set; }

        /// <summary>
        /// Key for CourseDefinedByType.
        /// </summary>
        public string definedByType { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string minimumAvailableCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? minimumAvailableCreditConversion { get; set; }

        /// <summary>
        /// The minimum amount of credit available to a student who successfully completes the course
        /// </summary>
        public double? minimumAvailableCredits { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string maximumAvailableCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? maximumAvailableCreditConversion { get; set; }

        /// <summary>
        /// The maximum amount of credit available to a student who successfully completes the course
        /// </summary>
        public double? maximumAvailableCredits { get; set; }

        /// <summary>
        /// Key for CareerPathway
        /// </summary>
        public string careerPathwayType { get; set; }

        /// <summary>
        /// The actual or estimated number of clock minutes required for class completion. This number is especially important for career and technical education classes and may represent (in minutes) the clock hour requirement of the class.
        /// </summary>
        public int? timeRequiredForCompletion { get; set; }

        /// <summary>
        /// An unordered collection of courseCompetencyLevels.  The competency levels defined to rate the student for the course.
        /// </summary>
        public List<CourseCompetencyLevel> competencyLevels { get; set; }

        /// <summary>
        /// An unordered collection of courseIdentificationCodes.  A standard code that identifies the organization of subject matter and related learning experiences provided for the instruction of students.
        /// </summary>
        public List<CourseIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of courseLearningObjectives.  Learning Objectives to be mastered in the course.
        /// </summary>
        public List<CourseLearningObjective> learningObjectives { get; set; }

        /// <summary>
        /// An unordered collection of courseLearningStandards.  Learning Standard(s) to be taught by the course.
        /// </summary>
        public List<CourseLearningStandard> learningStandards { get; set; }

        /// <summary>
        /// An unordered collection of courseLevelCharacteristics.  Indication of the nature and difficulty of instruction: Remedial, Basic, Honors, AP, IB, Dual Credit, CTE, etc.
        /// </summary>
        public List<CourseLevelCharacteristic> levelCharacteristics { get; set; }

        /// <summary>
        /// An unordered collection of courseOfferedGradeLevels.  The grade levels in which the course is offered.
        /// </summary>
        public List<CourseOfferedGradeLevel> offeredGradeLevels { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

