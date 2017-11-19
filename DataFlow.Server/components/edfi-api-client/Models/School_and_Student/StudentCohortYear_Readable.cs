using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.School_and_Student 
{
    public class StudentCohortYear_Readable 
    {
        /// <summary>
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference schoolYearTypeReference { get; set; }

        /// <summary>
        /// Key for CohortYear
        /// </summary>
        public string cohortYearType { get; set; }

        }
}
