namespace DataFlow.EdFi.Models.Types 
{
    public class AssessmentReportingMethodType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for AssessmentReportingMethod
        /// </summary>
        public int? assessmentReportingMethodTypeId { get; set; }

        /// <summary>
        /// Code for AssessmentReportingMethod type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the assessment reporting method type.  
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

