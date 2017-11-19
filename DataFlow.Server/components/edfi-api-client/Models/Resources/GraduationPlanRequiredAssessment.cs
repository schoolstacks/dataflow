using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class GraduationPlanRequiredAssessment 
    {
        /// <summary>
        /// A reference to the related Assessment resource.
        /// </summary>
        public AssessmentReference assessmentReference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GraduationPlanRequiredAssessmentAssessmentPerformanceLevel assessmentPerformanceLevel { get; set; }

        /// <summary>
        /// An unordered collection of graduationPlanRequiredAssessmentScores.  The total credits required for graduation by taking a specific course, or by taking one or more from a set of courses.
        /// </summary>
        public List<GraduationPlanRequiredAssessmentScore> scores { get; set; }

        }
}

