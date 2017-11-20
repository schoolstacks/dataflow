namespace DataFlow.EdFi.Models.Resources 
{
    public class ParentReference 
    {
        /// <summary>
        /// A unique alpha-numeric code assigned to a parent.
        /// </summary>
        public string parentUniqueId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related parent resource.
        /// </summary>
        public Link link { get; set; }

        }
}

