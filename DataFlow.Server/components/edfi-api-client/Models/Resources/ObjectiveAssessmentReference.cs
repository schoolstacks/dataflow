using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class ObjectiveAssessmentReference 
    {
        /// <summary>
        /// The title or name of the assessment.  NEDM: Assessment Title
        /// </summary>
        public string assessmentTitle { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        public string assessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The version identifier for the test assessment.  NEDM: Assessment Version
        /// </summary>
        public int? version { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.
        /// </summary>
        public string identificationCode { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related objectiveAssessment resource.
        /// </summary>
        public Link link { get; set; }

        }
}

