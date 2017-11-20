namespace DataFlow.EdFi.Models.Resources 
{
    public class AcademicWeekReference 
    {
        /// <summary>
        /// The school label for the academic week.
        /// </summary>
        public string weekIdentifier { get; set; }

        /// <summary>
        /// The identifier assigned to a school by the State Education Agency (SEA).
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related academicWeek resource.
        /// </summary>
        public Link link { get; set; }

        }
}

