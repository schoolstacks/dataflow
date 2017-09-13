using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentAssessmentStudentObjectiveAssessment 
    {
        /// <summary>
        /// A reference to the related ObjectiveAssessment resource.
        /// </summary>
        public ObjectiveAssessmentReference objectiveAssessmentReference { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentStudentObjectiveAssessmentPerformanceLevels.  The performance level(s) achieved for the objective assessment.
        /// </summary>
        public List<StudentAssessmentStudentObjectiveAssessmentPerformanceLevel> performanceLevels { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentStudentObjectiveAssessmentScoreResults.  A meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.
        /// </summary>
        public List<StudentAssessmentStudentObjectiveAssessmentScoreResult> scoreResults { get; set; }

        }
}

