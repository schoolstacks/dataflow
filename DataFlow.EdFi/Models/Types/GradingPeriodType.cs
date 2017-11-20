namespace DataFlow.EdFi.Models.Types 
{
    public class GradingPeriodType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for GradingPeriod
        /// </summary>
        public int? gradingPeriodTypeId { get; set; }

        /// <summary>
        /// Code for GradingPeriod type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// The sequential order of this period relative to other periods.
        /// </summary>
        public int? periodSequence { get; set; }

        /// <summary>
        /// A shortened description for the grading period type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

