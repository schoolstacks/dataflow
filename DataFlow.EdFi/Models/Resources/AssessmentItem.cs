using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class AssessmentItem 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Assessment resource.
        /// </summary>
        public AssessmentReference assessmentReference { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.
        /// </summary>
        public string identificationCode { get; set; }

        /// <summary>
        /// Category or type of the assessment item.  For example:  Multiple choice  Analytic  Prose  ....
        /// </summary>
        public string categoryType { get; set; }

        /// <summary>
        /// The maximum raw score achievable across all assessment items that are correct and scored at the maximum.
        /// </summary>
        public int? maxRawScore { get; set; }

        /// <summary>
        /// The correct response for the assessment item.
        /// </summary>
        public string correctResponse { get; set; }

        /// <summary>
        /// The duration of time allotted for the AssessmentItem.
        /// </summary>
        public string expectedTimeAssessed { get; set; }

        /// <summary>
        /// Reflects the common nomenclature for an element.
        /// </summary>
        public string nomenclature { get; set; }

        /// <summary>
        /// An unordered collection of assessmentItemLearningStandards.  Learning Standard tested by this item.
        /// </summary>
        public List<AssessmentItemLearningStandard> learningStandards { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

