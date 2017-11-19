using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class GraduationPlanRequiredAssessmentAssessmentPerformanceLevel 
    {
        /// <summary>
        /// The performance level(s) defined for the assessment.
        /// </summary>
        public string performanceLevelDescriptor { get; set; }

        /// <summary>
        /// The method that the instructor of the class uses to report the performance and achievement of all students. It may be a qualitative method such as individualized teacher comments or a quantitative method such as a letter or numerical grade. In some cases, more than one type of reporting method may be used.
        /// </summary>
        public string assessmentReportingMethodType { get; set; }

        /// <summary>
        /// The minimum score required to make the indicated level of performance.
        /// </summary>
        public string minimumScore { get; set; }

        /// <summary>
        /// The maximum score to make the indicated level of performance.
        /// </summary>
        public string maximumScore { get; set; }

        /// <summary>
        /// The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.
        /// </summary>
        public string resultDatatypeType { get; set; }

        }
}

