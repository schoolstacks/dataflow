namespace DataFlow.EdFi.Models.Types 
{
    public class DisabilityType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for Disability
        /// </summary>
        public int? disabilityTypeId { get; set; }

        /// <summary>
        /// Code for Disability type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description for Disability type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Short description for the disability type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

