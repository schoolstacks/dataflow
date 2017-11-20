namespace DataFlow.EdFi.Models.Types 
{
    public class ReasonNotTestedType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for ReasonNotTested
        /// </summary>
        public int? reasonNotTestedTypeId { get; set; }

        /// <summary>
        /// Code for ReasonNotTested type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the reason not tested type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

