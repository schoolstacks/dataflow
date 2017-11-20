namespace DataFlow.EdFi.Models.School_and_Student 
{
    public class LocalEducationAgencyReference 
    {
        /// <summary>
        /// The identifier assigned to a local education agency by the State Education Agency (SEA).
        /// </summary>
        public int? localEducationAgencyId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related localEducationAgency resource.
        /// </summary>
        public Link link { get; set; }

        }
}

