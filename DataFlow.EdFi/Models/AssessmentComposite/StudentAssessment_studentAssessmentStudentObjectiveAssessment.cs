using System.Collections.Generic;

namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class StudentAssessment_studentAssessmentStudentObjectiveAssessment 
    {
        /// <summary>
        /// A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.
        /// </summary>
        public string identificationCode { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentStudentObjectiveAssessmentPerformanceLevels.  
        /// </summary>
        public List<StudentAssessment_studentAssessmentStudentObjectiveAssessment_studentAssessmentStudentObjectiveAssessmentPerformanceLevel> performanceLevels { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentStudentObjectiveAssessmentScoreResults.  
        /// </summary>
        public List<StudentAssessment_studentAssessmentStudentObjectiveAssessment_studentAssessmentStudentObjectiveAssessmentScoreResult> scoreResults { get; set; }

        }
}

