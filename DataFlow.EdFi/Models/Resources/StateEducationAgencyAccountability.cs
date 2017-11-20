namespace DataFlow.EdFi.Models.Resources 
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

