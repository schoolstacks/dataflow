using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class Assessment 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The title or name of the assessment.  NEDM: Assessment Title
        /// </summary>
        public string assessmentTitle { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject
        /// </summary>
        public string academicSubjectType { get; set; }

        /// <summary>
        /// The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        public string assessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        public string assessedGradeLevelType { get; set; }

        /// <summary>
        /// The version identifier for the assessment.
        /// </summary>
        public int? version { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string assessmentCategoryDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string assessmentCategoryType { get; set; }

        /// <summary>
        /// Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.
        /// </summary>
        public string assessmentForm { get; set; }

        /// <summary>
        /// The ID of the Assessment Period Descriptor
        /// </summary>
        public string assessmentPeriodDescriptor { get; set; }

        /// <summary>
        /// If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        public string lowestAssessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        public string lowestAssessedGradeLevelType { get; set; }

        /// <summary>
        /// The maximum raw score achievable across all assessment items that are correct and scored at the maximum.
        /// </summary>
        public int? maxRawScore { get; set; }

        /// <summary>
        /// Namespace for the Assessment.
        /// </summary>
        public string @namespace { get; set; }

        /// <summary>
        /// Reflects the common nomenclature for an element.
        /// </summary>
        public string nomenclature { get; set; }

        /// <summary>
        /// The month, day, and year that the conceptual design for the assessment was most recently revised substantially.
        /// </summary>
        public DateTime? revisionDate { get; set; }

        /// <summary>
        /// An unordered collection of assessmentIdentificationCodes.  
        /// </summary>
        public List<Assessment_assessmentIdentificationCode> assessmentIdentificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of assessmentPerformanceLevels.  
        /// </summary>
        public List<Assessment_assessmentPerformanceLevel> assessmentPerformanceLevels { get; set; }

        /// <summary>
        /// An unordered collection of objectiveAssessments.  
        /// </summary>
        public List<Assessment_objectiveAssessment> objectiveAssessments { get; set; }

        }
}

