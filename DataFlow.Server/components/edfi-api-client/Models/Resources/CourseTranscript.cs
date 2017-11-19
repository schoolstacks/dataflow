using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class CourseTranscript 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Course resource.
        /// </summary>
        public CourseReference courseReference { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

        /// <summary>
        /// A reference to the related StudentAcademicRecord resource.
        /// </summary>
        public StudentAcademicRecordReference studentAcademicRecordReference { get; set; }

        /// <summary>
        /// The result from the student''s attempt to take the course, for example:  Pass  Fail  Incomplete  Withdrawn  Expelled
        /// </summary>
        public string courseAttemptResultType { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string attemptedCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? attemptedCreditConversion { get; set; }

        /// <summary>
        /// The number of credits attempted for a course.
        /// </summary>
        public double? attemptedCredits { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string earnedCreditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? earnedCreditConversion { get; set; }

        /// <summary>
        /// The number of credits awarded or earned for the course.
        /// </summary>
        public double? earnedCredits { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.  
        /// </summary>
        public string whenTakenGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The method the credits were earned, for example:  Classroom, Examination, Transfer
        /// </summary>
        public string methodCreditEarnedType { get; set; }

        /// <summary>
        /// The final indicator of student performance in a class as submitted by the instructor.
        /// </summary>
        public string finalLetterGradeEarned { get; set; }

        /// <summary>
        /// The final indicator of student performance in a class as submitted by the instructor.
        /// </summary>
        public double? finalNumericGradeEarned { get; set; }

        /// <summary>
        /// Indicates that an academic course has been repeated by a student and how that repeat is to be computed in the student''s academic grade average.
        /// </summary>
        public string courseRepeatCodeType { get; set; }

        /// <summary>
        /// The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, and language arts).
        /// </summary>
        public string courseTitle { get; set; }

        /// <summary>
        /// The descriptive name given to a course of study offered in the school, if different from the CourseTitle.
        /// </summary>
        public string alternativeCourseTitle { get; set; }

        /// <summary>
        /// The local code assigned by the school that identifies the course offering, the code from an external educational organization, or other alternate course code.
        /// </summary>
        public string alternativeCourseCode { get; set; }

        /// <summary>
        /// An unordered collection of courseTranscriptEarnedAdditionalCredits.  Additional credits or units of value awarded for the completion of a course (e.g., AP, IB, Dual Credits).
        /// </summary>
        public List<CourseTranscriptEarnedAdditionalCredits> earnedAdditionalCredits { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

