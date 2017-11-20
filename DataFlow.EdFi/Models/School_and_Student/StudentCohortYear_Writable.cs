namespace DataFlow.EdFi.Models.School_and_Student 
{
    public class StudentCohortYear_Writable 
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

