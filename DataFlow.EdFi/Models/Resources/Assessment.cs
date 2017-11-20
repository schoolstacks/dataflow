using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class Assessment 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related AssessmentFamily resource.
        /// </summary>
        public AssessmentFamilyReference assessmentFamilyReference { get; set; }

        /// <summary>
        /// The title or name of the assessment.  NEDM: Assessment Title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        public string assessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// The version identifier for the assessment.
        /// </summary>
        public int? version { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string categoryDescriptor { get; set; }

        /// <summary>
        /// If the test assessment spans a range of grades, then this attribute holds the lowest grade assessed.  If only one grade level is assessed, then this attribute is omitted. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        public string lowestAssessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.
        /// </summary>
        public string form { get; set; }

        /// <summary>
        /// The month, day, and year that the conceptual design for the assessment was most recently revised substantially.
        /// </summary>
        public DateTime? revisionDate { get; set; }

        /// <summary>
        /// The maximum raw score achievable across all assessment items that are correct and scored at the maximum.
        /// </summary>
        public int? maxRawScore { get; set; }

        /// <summary>
        /// Reflects the common nomenclature for an element.
        /// </summary>
        public string nomenclature { get; set; }

        /// <summary>
        /// The ID of the Assessment Period Descriptor
        /// </summary>
        public string periodDescriptor { get; set; }

        /// <summary>
        /// Namespace for the Assessment.
        /// </summary>
        public string @namespace { get; set; }

        /// <summary>
        /// An indication as to whether an assessment conforms to a standard.
        /// </summary>
        public AssessmentContentStandard contentStandard { get; set; }

        /// <summary>
        /// An unordered collection of assessmentIdentificationCodes.  A unique number or alphanumeric code assigned to an assessment by a school, school system, a state, or other agency or entity.
        /// </summary>
        public List<AssessmentIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of assessmentLanguages.  An indication of the languages in which the Assessment is designed.
        /// </summary>
        public List<AssessmentLanguage> languages { get; set; }

        /// <summary>
        /// An unordered collection of assessmentPerformanceLevels.  Definition of the performance levels and the associated cut scores. Three styles are supported: 1. Specification of performance level by minimum and maximum score 2. Specification of performance level by cut score, using only minimum score 3. Specification of performance level without any mapping to scores .
        /// </summary>
        public List<AssessmentPerformanceLevel> performanceLevels { get; set; }

        /// <summary>
        /// An unordered collection of assessmentPrograms.  The programs associated with the Assessment.
        /// </summary>
        public List<AssessmentProgram> programs { get; set; }

        /// <summary>
        /// An unordered collection of assessmentScores.  Definition of the scores to be expected from this assessment.
        /// </summary>
        public List<AssessmentScore> scores { get; set; }

        /// <summary>
        /// An unordered collection of assessmentSections.  The section(s) to which the Assessment is associated.
        /// </summary>
        public List<AssessmentSection> sections { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

