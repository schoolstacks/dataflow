using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentAcademicRecordClassRanking 
    {
        /// <summary>
        /// The academic rank of a student in relation to his or her graduating class (e.g., 1st, 2nd, 3rd).
        /// </summary>
        public int? classRank { get; set; }

        /// <summary>
        /// The total number of students in the student's graduating class.
        /// </summary>
        public int? totalNumberInClass { get; set; }

        /// <summary>
        /// The academic percentage rank of a student in relation to his or her graduating class (e.g., 95%, 80%, 50%).
        /// </summary>
        public int? percentageRanking { get; set; }

        /// <summary>
        /// Date class ranking was determined.
        /// </summary>
        public DateTime? classRankingDate { get; set; }

        }
}

