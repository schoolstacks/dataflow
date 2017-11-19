using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class AssessmentReference 
    {
        /// <summary>
        /// The title or name of the assessment.  NEDM: Assessment Title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        public string assessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// The version identifier for the assessment.
        /// </summary>
        public int? version { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related assessment resource.
        /// </summary>
        public Link link { get; set; }

        }
}

