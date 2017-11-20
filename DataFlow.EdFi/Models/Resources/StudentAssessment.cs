using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentAssessment 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Assessment resource.
        /// </summary>
        public AssessmentReference assessmentReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.
        /// </summary>
        public DateTime? administrationDate { get; set; }

        /// <summary>
        /// Assessment Administration End Date, if administered over multiple days.
        /// </summary>
        public DateTime? administrationEndDate { get; set; }

        /// <summary>
        /// The unique number for the assessment form or answer document.
        /// </summary>
        public string serialNumber { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string administrationLanguageDescriptor { get; set; }

        /// <summary>
        /// The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....
        /// </summary>
        public string administrationEnvironmentType { get; set; }

        /// <summary>
        /// Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...
        /// </summary>
        public string retestIndicatorType { get; set; }

        /// <summary>
        /// The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...
        /// </summary>
        public string reasonNotTestedType { get; set; }

        /// <summary>
        /// The grade level of a student when assessed.
        /// </summary>
        public string whenAssessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string eventCircumstanceType { get; set; }

        /// <summary>
        /// Describes special events that occur before during or after the assessment session that may impact use of results.
        /// </summary>
        public string eventDescription { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentAccommodations.  The specific type of special variation used in how an examination is presented, how it is administered or how the test taker is allowed to respond. This generally refers to changes that do not substantially alter what the examination measures. The proper use of accommodations does not substantially change academic level or performance criteria (e.g., Braille, Enlarged Monitor View, Extra Time, Large Print, Setting, Oral Administration).
        /// </summary>
        public List<StudentAssessmentAccommodation> accommodations { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentItems.  This entity represents the student's response to an assessment item and the item-level scores such as correct, incorrect, or met standard.
        /// </summary>
        public List<StudentAssessmentItem> items { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentPerformanceLevels.  Indicates the various levels or thresholds for the performance achieved by the student on the assessment.
        /// </summary>
        public List<StudentAssessmentPerformanceLevel> performanceLevels { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentScoreResults.  A meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.
        /// </summary>
        public List<StudentAssessmentScoreResult> scoreResults { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentStudentObjectiveAssessments.  This entity holds the score and or performance levels earned for an objective assessment by a student.
        /// </summary>
        public List<StudentAssessmentStudentObjectiveAssessment> studentObjectiveAssessments { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

