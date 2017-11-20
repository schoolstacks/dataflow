namespace DataFlow.EdFi.Models.Types 
{
    public class AdministrationEnvironmentType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for AdministrationEnvironment
        /// </summary>
        public int? administrationEnvironmentTypeId { get; set; }

        /// <summary>
        /// Code for AdministrationEnvironment type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the administration environment type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

