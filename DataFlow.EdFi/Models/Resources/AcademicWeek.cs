namespace DataFlow.EdFi.Models.Resources 
{
    public class AcademicWeek 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related CalendarDate resource.
        /// </summary>
        public CalendarDateReference beginCalendarDateReference { get; set; }

        /// <summary>
        /// A reference to the related CalendarDate resource.
        /// </summary>
        public CalendarDateReference endCalendarDateReference { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

        /// <summary>
        /// The school label for the academic week.
        /// </summary>
        public string weekIdentifier { get; set; }

        /// <summary>
        /// The total instructional days during the academic week.
        /// </summary>
        public int? totalInstructionalDays { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

