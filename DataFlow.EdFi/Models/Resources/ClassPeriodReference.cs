namespace DataFlow.EdFi.Models.Resources 
{
    public class ClassPeriodReference 
    {
        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related classPeriod resource.
        /// </summary>
        public Link link { get; set; }

        }
}

