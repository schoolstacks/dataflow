using System.Collections.Generic;

namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class Assessment_objectiveAssessment_objectiveAssessmentLearningObjective_learningObjectiveLearningStandard 
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Subject area for the learning standard.
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// Subject area for the learning standard.
        /// </summary>
        public string academicSubjectType { get; set; }

        /// <summary>
        /// A detailed description of the entity.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a Learning Standard.
        /// </summary>
        public string learningStandardId { get; set; }

        /// <summary>
        /// Namespace for the LearningStandard.
        /// </summary>
        public string @namespace { get; set; }

        /// <summary>
        /// The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, and language arts).
        /// </summary>
        public string courseTitle { get; set; }

        /// <summary>
        /// A code designated by the promulgating body to identify the statement, e.g. 1.N.3 (usually not globally unique).
        /// </summary>
        public string learningStandardItemCode { get; set; }

        /// <summary>
        /// One or more statements that describes the criteria used by teachers and students to check for attainment of a learning standard. This criteria gives clear indications as to the degree to which learning is moving through the Zone or Proximal Development toward independent achievement of the LearningStandard.
        /// </summary>
        public string successCriteria { get; set; }

        /// <summary>
        /// The public web site address (URL), file, or ftp locator.
        /// </summary>
        public string uri { get; set; }

        /// <summary>
        /// An unordered collection of learningStandardIdentificationCodes.  
        /// </summary>
        public List<Assessment_objectiveAssessment_objectiveAssessmentLearningObjective_learningObjectiveLearningStandard_learningStandardIdentificationCode> learningStandardIdentificationCodes { get; set; }

        }
}

