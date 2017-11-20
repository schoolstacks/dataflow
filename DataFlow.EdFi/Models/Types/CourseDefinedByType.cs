namespace DataFlow.EdFi.Models.Types 
{
    public class CourseDefinedByType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for CourseDefinedByType.
        /// </summary>
        public int? courseDefinedByTypeId { get; set; }

        /// <summary>
        /// Code value for the course defined by type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the course defined by type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

