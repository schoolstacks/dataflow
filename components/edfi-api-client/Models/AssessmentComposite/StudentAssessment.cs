using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.AssessmentComposite 
{
    public class StudentAssessment 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a student by a state education agency.
        /// </summary>
        public int? studentUniqueId { get; set; }

        /// <summary>
        /// The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.
        /// </summary>
        public DateTime? administrationDate { get; set; }

        /// <summary>
        /// Assessment Administration End Date, if administered over multiple days.
        /// </summary>
        public DateTime? administrationEndDate { get; set; }

        /// <summary>
        /// The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....
        /// </summary>
        public string administrationEnvironmentType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string administrationLanguageDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string administrationLanguageType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string eventCircumstanceType { get; set; }

        /// <summary>
        /// Describes special events that occur before during or after the assessment session that may impact use of results.
        /// </summary>
        public string eventDescription { get; set; }

        /// <summary>
        /// The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...
        /// </summary>
        public string reasonNotTestedType { get; set; }

        /// <summary>
        /// Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...
        /// </summary>
        public string retestIndicatorType { get; set; }

        /// <summary>
        /// The unique number for the assessment form or answer document.
        /// </summary>
        public string serialNumber { get; set; }

        /// <summary>
        /// The grade level of a student when assessed.
        /// </summary>
        public string whenAssessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The grade level of a student when assessed.
        /// </summary>
        public string whenAssessedGradeLevelType { get; set; }

        public StudentAssessment_assessment assessmentReference { get; set; }

        public StudentAssessment_student student { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentAccommodations.  
        /// </summary>
        public List<StudentAssessment_studentAssessmentAccommodation> accommodations { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentPerformanceLevels.  
        /// </summary>
        public List<StudentAssessment_studentAssessmentPerformanceLevel> performanceLevels { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentScoreResults.  
        /// </summary>
        public List<StudentAssessment_studentAssessmentScoreResult> scoreResults { get; set; }

        /// <summary>
        /// An unordered collection of studentAssessmentStudentObjectiveAssessments.  
        /// </summary>
        public List<StudentAssessment_studentAssessmentStudentObjectiveAssessment> objectiveAssessments { get; set; }

        }
}

