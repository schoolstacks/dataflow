namespace DataFlow.EdFi.Models.Types 
{
    public class ReasonExitedType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for ReasonExited
        /// </summary>
        public int? reasonExitedTypeId { get; set; }

        /// <summary>
        /// Code for ReasonExited type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description for ReasonExited type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the descriptor.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

