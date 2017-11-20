using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentGradebookEntry 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related GradebookEntry resource.
        /// </summary>
        public GradebookEntryReference gradebookEntryReference { get; set; }

        /// <summary>
        /// A reference to the related StudentSectionAssociation resource.
        /// </summary>
        public StudentSectionAssociationReference studentSectionAssociationReference { get; set; }

        /// <summary>
        /// The date an assignment was turned in or the date of an assessment.
        /// </summary>
        public DateTime? dateFulfilled { get; set; }

        /// <summary>
        /// A final or interim (grading period) indicator of student performance in a class as submitted by the instructor.
        /// </summary>
        public string letterGradeEarned { get; set; }

        /// <summary>
        /// A final or interim (grading period) indicator of student performance in a class as submitted by the instructor.
        /// </summary>
        public double? numericGradeEarned { get; set; }

        /// <summary>
        /// The competency level assessed for the student for the referenced learning objective.
        /// </summary>
        public string competencyLevelDescriptor { get; set; }

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

