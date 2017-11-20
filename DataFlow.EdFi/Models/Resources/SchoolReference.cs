namespace DataFlow.EdFi.Models.Resources 
{
    public class SchoolReference 
    {
        /// <summary>
        /// The identifier assigned to a school by the State Education Agency (SEA).
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related school resource.
        /// </summary>
        public Link link { get; set; }

        }
}

