using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class GraduationPlanCreditsByCourse 
    {
        /// <summary>
        /// Identifying name given to a collection of courses.
        /// </summary>
        public string courseSetName { get; set; }

        /// <summary>
        /// The value of credits or units of value awarded for the completion of a course.
        /// </summary>
        public double? credits { get; set; }

        /// <summary>
        /// Key for Credit
        /// </summary>
        public string creditType { get; set; }

        /// <summary>
        /// Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.
        /// </summary>
        public double? creditConversion { get; set; }

        /// <summary>
        /// The grade level when the student is planned to take the course.
        /// </summary>
        public string whenTakenGradeLevelDescriptor { get; set; }

        /// <summary>
        /// An unordered collection of graduationPlanCreditsByCourseCourses.  
        /// </summary>
        public List<GraduationPlanCreditsByCourseCourse> courses { get; set; }

        }
}

