namespace DataFlow.EdFi.Models.Resources 
{
    public class Link 
    {
        /// <summary>
        /// Describes the nature of the relationship to the referenced resource.
        /// </summary>
        public string rel { get; set; }

        /// <summary>
        /// The URL to the related resource.
        /// </summary>
        public string href { get; set; }

        }
}

