using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class GraduationPlanRequiredAssessmentScore 
    {
        /// <summary>
        /// The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.
        /// </summary>
        public string assessmentReportingMethodType { get; set; }

        /// <summary>
        /// The minimum score possible on the assessment.
        /// </summary>
        public string minimumScore { get; set; }

        /// <summary>
        /// The maximum score possible on the assessment.
        /// </summary>
        public string maximumScore { get; set; }

        /// <summary>
        /// The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.
        /// </summary>
        public string resultDatatypeType { get; set; }

        }
}

