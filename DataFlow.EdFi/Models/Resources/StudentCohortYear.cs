namespace DataFlow.EdFi.Models.Resources 
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

