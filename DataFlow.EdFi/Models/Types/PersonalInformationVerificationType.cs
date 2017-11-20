namespace DataFlow.EdFi.Models.Types 
{
    public class PersonalInformationVerificationType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for PersonalInformationVerification
        /// </summary>
        public int? personalInformationVerificationTypeId { get; set; }

        /// <summary>
        /// Code for PersonalInformationVerification type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the personal information verification type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

