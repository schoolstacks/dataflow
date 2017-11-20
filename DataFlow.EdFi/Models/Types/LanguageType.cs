namespace DataFlow.EdFi.Models.Types 
{
    public class LanguageType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Language(s) the individual uses to communicate
        /// </summary>
        public int? languageTypeId { get; set; }

        /// <summary>
        /// Code for Languages type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description for Languages type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Short description for languages type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

