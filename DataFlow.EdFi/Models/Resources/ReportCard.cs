using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class ReportCard 
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
        /// A reference to the related GradingPeriod resource.
        /// </summary>
        public GradingPeriodReference gradingPeriodReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// A measure of average performance in all courses taken by an individual for the current grading period.
        /// </summary>
        public double? gpaGivenGradingPeriod { get; set; }

        /// <summary>
        /// A measure of cumulative average performance in all courses taken by an individual from the beginning of the school year through the current grading period.
        /// </summary>
        public double? gpaCumulative { get; set; }

        /// <summary>
        /// The number of days an individual is absent when school is in session during a given reporting period.
        /// </summary>
        public double? numberOfDaysAbsent { get; set; }

        /// <summary>
        /// The number of days an individual is present when school is in session during a given reporting period.
        /// </summary>
        public double? numberOfDaysInAttendance { get; set; }

        /// <summary>
        /// The number of days an individual is tardy during a given reporting period.
        /// </summary>
        public int? numberOfDaysTardy { get; set; }

        /// <summary>
        /// An unordered collection of reportCardGrades.  Grades for the classes attended by the student for this grading period.
        /// </summary>
        public List<ReportCardGrade> grades { get; set; }

        /// <summary>
        /// An unordered collection of reportCardStudentCompetencyObjectives.  The student competency evaluations associated for this grading period.
        /// </summary>
        public List<ReportCardStudentCompetencyObjective> studentCompetencyObjectives { get; set; }

        /// <summary>
        /// An unordered collection of reportCardStudentLearningObjectives.  
        /// </summary>
        public List<ReportCardStudentLearningObjective> studentLearningObjectives { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

