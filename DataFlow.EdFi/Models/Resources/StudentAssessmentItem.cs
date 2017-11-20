namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentAssessmentItem 
    {
        /// <summary>
        /// A reference to the related AssessmentItem resource.
        /// </summary>
        public AssessmentItemReference assessmentItemReference { get; set; }

        /// <summary>
        /// A student's response to a stimulus on a test.
        /// </summary>
        public string assessmentResponse { get; set; }

        /// <summary>
        /// Indicator of the response.  For example:  Nonscorable response  Ineffective response  Effective response  Partial response  ...
        /// </summary>
        public string responseIndicatorType { get; set; }

        /// <summary>
        /// The analyzed result of a student''s response to an assessment item.. For example:  Correct  Incorrect  Met standard  ...
        /// </summary>
        public string assessmentItemResultType { get; set; }

        /// <summary>
        /// A meaningful raw score of the performance of an individual on an assessment item.
        /// </summary>
        public int? rawScoreResult { get; set; }

        /// <summary>
        /// The overall time a student actually spent during the AssessmentItem.
        /// </summary>
        public string timeAssessed { get; set; }

        /// <summary>
        /// The formative descriptive feedback that was given to a learner in response to the results from a scored/evaluated assessment item.
        /// </summary>
        public string descriptiveFeedback { get; set; }

        }
}

