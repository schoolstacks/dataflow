using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class LearningStandard 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related LearningStandard resource.
        /// </summary>
        public LearningStandardReference parentLearningStandardReference { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a Learning Standard.
        /// </summary>
        public string learningStandardId { get; set; }

        /// <summary>
        /// A detailed description of the entity.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A code designated by the promulgating body to identify the statement, e.g. 1.N.3 (usually not globally unique).
        /// </summary>
        public string itemCode { get; set; }

        /// <summary>
        /// The public web site address (URL), file, or ftp locator.
        /// </summary>
        public string uri { get; set; }

        /// <summary>
        /// Subject area for the learning standard.
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, and language arts).
        /// </summary>
        public string courseTitle { get; set; }

        /// <summary>
        /// One or more statements that describes the criteria used by teachers and students to check for attainment of a learning standard. This criteria gives clear indications as to the degree to which learning is moving through the Zone or Proximal Development toward independent achievement of the LearningStandard.
        /// </summary>
        public string successCriteria { get; set; }

        /// <summary>
        /// Namespace for the LearningStandard.
        /// </summary>
        public string @namespace { get; set; }

        /// <summary>
        /// The Content Standard from which the Learning Standard was derived.
        /// </summary>
        public LearningStandardContentStandard contentStandard { get; set; }

        /// <summary>
        /// An unordered collection of learningStandardGradeLevels.  
        /// </summary>
        public List<LearningStandardGradeLevel> gradeLevels { get; set; }

        /// <summary>
        /// An unordered collection of learningStandardIdentificationCodes.  A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a learning Standard.
        /// </summary>
        public List<LearningStandardIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of learningStandardPrerequisiteLearningStandards.  
        /// </summary>
        public List<LearningStandardPrerequisiteLearningStandard> prerequisiteLearningStandards { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

