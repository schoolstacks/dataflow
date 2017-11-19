using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentLearningObjectiveReference 
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
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// The grade level for which the learning objective is targeted,
        /// </summary>
        public string objectiveGradeLevelDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string gradingPeriodDescriptor { get; set; }

        /// <summary>
        /// Month, day, and year of the first day of the GradingPeriod.
        /// </summary>
        public DateTime? gradingPeriodBeginDate { get; set; }

        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related studentLearningObjective resource.
        /// </summary>
        public Link link { get; set; }

        }
}

