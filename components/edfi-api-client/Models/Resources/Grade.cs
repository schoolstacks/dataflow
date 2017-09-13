using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class Grade 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related GradingPeriod resource.
        /// </summary>
        public GradingPeriodReference gradingPeriodReference { get; set; }

        /// <summary>
        /// A reference to the related StudentSectionAssociation resource.
        /// </summary>
        public StudentSectionAssociationReference studentSectionAssociationReference { get; set; }

        /// <summary>
        /// The type of grade (e.g., Exam, Final, Grading Period, Progress Report)
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The performance base conversion assessed for the student.
        /// </summary>
        public string performanceBaseConversionType { get; set; }

        /// <summary>
        /// A final or interim (grading period) indicator of student performance in a class as submitted by the instructor.
        /// </summary>
        public string letterGradeEarned { get; set; }

        /// <summary>
        /// A final or interim (grading period) indicator of student performance in a class as submitted by the instructor.
        /// </summary>
        public double? numericGradeEarned { get; set; }

        /// <summary>
        /// A statement provided by the teacher that provides information in addition to the grade or assessment score.
        /// </summary>
        public string diagnosticStatement { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

