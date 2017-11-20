namespace DataFlow.EdFi.Models.Types 
{
    public class PostSecondaryEventCategoryType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for PostSecondaryEventCategory
        /// </summary>
        public int? postSecondaryEventCategoryTypeId { get; set; }

        /// <summary>
        /// Code for PostSecondaryEventCategory type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the post secondary event category type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

