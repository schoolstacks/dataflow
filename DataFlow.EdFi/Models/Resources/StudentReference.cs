namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentReference 
    {
        /// <summary>
        /// A unique alpha-numeric code assigned to a student.
        /// </summary>
        public string studentUniqueId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related student resource.
        /// </summary>
        public Link link { get; set; }

        }
}

