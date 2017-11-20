namespace DataFlow.EdFi.Models.Types 
{
    public class AdditionalCreditType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public int? additionalCreditTypeId { get; set; }

        /// <summary>
        /// Code for additional credit type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// A shortened description for the additional credit type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// Description of additional Credit type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

