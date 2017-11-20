namespace DataFlow.EdFi.Models.Types 
{
    public class ReporterDescriptionType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for ReporterDescription
        /// </summary>
        public int? reporterDescriptionTypeId { get; set; }

        /// <summary>
        /// Code for ReporterDescription type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the reporter description type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

