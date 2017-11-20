namespace DataFlow.EdFi.Models.School_and_Student 
{
    public class SchoolYearTypeReference 
    {
        /// <summary>
        /// Key for School
        /// </summary>
        public int? schoolYear { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related schoolYearType resource.
        /// </summary>
        public Link link { get; set; }

        }
}

