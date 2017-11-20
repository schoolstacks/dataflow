namespace DataFlow.EdFi.Models.Types 
{
    public class EmploymentStatusType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for EmploymentStatus
        /// </summary>
        public int? employmentStatusTypeId { get; set; }

        /// <summary>
        /// Code for EmploymentStatus type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description for EmploymentStatus type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Short description for employment status type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

