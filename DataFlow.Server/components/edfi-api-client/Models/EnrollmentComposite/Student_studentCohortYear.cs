using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.EnrollmentComposite 
{
    public class Student_studentCohortYear 
    {
        /// <summary>
        /// Key for CohortYear
        /// </summary>
        public string cohortYearType { get; set; }

        /// <summary>
        /// The identifier for the school year.
        /// </summary>
        public int? schoolYear { get; set; }

        }
}

