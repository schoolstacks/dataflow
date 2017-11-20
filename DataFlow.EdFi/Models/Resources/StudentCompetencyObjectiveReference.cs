using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentCompetencyObjectiveReference 
    {
        /// <summary>
        /// A unique alpha-numeric code assigned to a student.
        /// </summary>
        public string studentUniqueId { get; set; }

        /// <summary>
        /// The designated title of the learning objective.
        /// </summary>
        public string objective { get; set; }

        /// <summary>
        /// The grade level for which the learning objective is targeted,
        /// </summary>
        public string objectiveGradeLevelDescriptor { get; set; }

        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? objectiveEducationOrganizationId { get; set; }

        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// The name of the grading period during the school year in which the grade is offered (e.g., 1st cycle, 1st semester)
        /// </summary>
        public string gradingPeriodDescriptor { get; set; }

        /// <summary>
        /// Month, day, and year of the first day of the GradingPeriod.
        /// </summary>
        public DateTime? gradingPeriodBeginDate { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related studentCompetencyObjective resource.
        /// </summary>
        public Link link { get; set; }

        }
}

