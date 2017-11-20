namespace DataFlow.EdFi.Models.Types 
{
    public class EntryType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for Entry
        /// </summary>
        public int? entryTypeId { get; set; }

        /// <summary>
        /// Code for Entry type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description for Entry type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Short description for entry type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

