namespace DataFlow.EdFi.Models.Types 
{
    public class LeaveEventCategoryType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for LeaveEventCategory
        /// </summary>
        public int? leaveEventCategoryTypeId { get; set; }

        /// <summary>
        /// Code for LeaveEventCategory type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the leave event category type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

