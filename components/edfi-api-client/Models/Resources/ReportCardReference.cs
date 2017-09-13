using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class ReportCardReference 
    {
        /// <summary>
        /// A unique alpha-numeric code assigned to a student.
        /// </summary>
        public string studentUniqueId { get; set; }

        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// The name of the grading period during the school year in which the grade is offered (e.g., 1st cycle, 1st semester)
        /// </summary>
        public string gradingPeriodDescriptor { get; set; }

        /// <summary>
        /// Month, day, and year of the first day of the grading period.
        /// </summary>
        public DateTime? gradingPeriodBeginDate { get; set; }

        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related reportCard resource.
        /// </summary>
        public Link link { get; set; }

        }
}

