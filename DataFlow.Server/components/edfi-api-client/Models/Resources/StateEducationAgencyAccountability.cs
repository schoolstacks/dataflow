using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StateEducationAgencyAccountability 
    {
        /// <summary>
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference schoolYearTypeReference { get; set; }

        /// <summary>
        /// An indication of whether CTE concentrators are included in the state's computation of its graduation rate.
        /// </summary>
        public bool? cteGraduationRateInclusion { get; set; }

        }
}

