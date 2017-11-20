namespace DataFlow.EdFi.Models.Types 
{
    public class CourseGPAApplicabilityType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for CourseGPAApplicability
        /// </summary>
        public int? courseGPAApplicabilityTypeId { get; set; }

        /// <summary>
        /// Code for CourseGPAApplicability type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the course GPA applicability type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

