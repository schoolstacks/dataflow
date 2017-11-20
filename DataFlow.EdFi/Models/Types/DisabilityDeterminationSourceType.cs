namespace DataFlow.EdFi.Models.Types 
{
    public class DisabilityDeterminationSourceType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for Disability Determination Source Type
        /// </summary>
        public int? disabilityDeterminationSourceTypeId { get; set; }

        /// <summary>
        /// Code of the Disability Determination Source Type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description of the Disability Determination Source Type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Short description of the Disability Determination Source Type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

