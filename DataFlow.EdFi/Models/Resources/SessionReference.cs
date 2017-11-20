namespace DataFlow.EdFi.Models.Resources 
{
    public class SessionReference 
    {
        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// The identifier for the school year (e.g., 2010/11).
        /// </summary>
        public int? schoolYear { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string termDescriptor { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related session resource.
        /// </summary>
        public Link link { get; set; }

        }
}

