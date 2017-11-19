using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentCohortYear 
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

