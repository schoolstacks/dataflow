namespace DataFlow.EdFi.Models.EnrollmentComposite 
{
    public class SectionEnrollment_classPeriod 
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period
        /// </summary>
        public string name { get; set; }

        }
}

