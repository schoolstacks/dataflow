namespace DataFlow.EdFi.Models.Types 
{
    public class StaffClassificationType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for StaffClassification
        /// </summary>
        public int? staffClassificationTypeId { get; set; }

        /// <summary>
        /// Code for StaffClassification type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description for StaffClassification type.
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

