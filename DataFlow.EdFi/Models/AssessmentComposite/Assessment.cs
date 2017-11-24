using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class Assessment 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// The title or name of the assessment.  NEDM: Assessment Title
        /// </summary>
        [JsonProperty(PropertyName = "assessmentTitle")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Assessment Title.")]
        [Display(Name = "Assessment Title")]
        public string AssessmentTitle { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject
        /// </summary>
        [JsonProperty(PropertyName = "academicSubjectDescriptor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an Academic Subject.")]
        [Display(Name = "Academic Subject")]
        public string AcademicSubjectDescriptor { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject
        /// </summary>
        [JsonProperty(PropertyName = "academicSubjectType")]
        public string AcademicSubjectType { get; set; }

        /// <summary>
        /// The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        [JsonProperty(PropertyName = "assessedGradeLevelDescriptor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select the grade level(s) for this assessment.")]
        public string AssessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...
        /// </summary>
        public string assessedGradeLevelType { get; set; }

        /// <summary>
        /// The version identifier for the assessment.
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Assessment Version.")]
        public int? Version { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        [JsonProperty(PropertyName = "assessmentCategoryDescriptor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an Assessment Category.")]
        [Display(Name = "Category")]
        public string AssessmentCategoryDescriptor { get; set; }

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
        [JsonProperty(PropertyName = "@namespace")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Assessment Namespace.")]
        public string Namespace { get; set; }

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
        [JsonProperty(PropertyName = "assessmentIdentificationCodes")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an Identification Code.")]
        [Display(Name = "Identification Code")]
        public List<Assessment_assessmentIdentificationCode> AssessmentIdentificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of assessmentPerformanceLevels.  
        /// </summary>
        public List<Assessment_assessmentPerformanceLevel> assessmentPerformanceLevels { get; set; }

        /// <summary>
        /// An unordered collection of objectiveAssessments.  
        /// </summary>
        [JsonProperty(PropertyName = "objectiveAssessments")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter object assessments.")]
        [Display(Name = "Objective Assessments")]
        public List<Assessment_objectiveAssessment> ObjectiveAssessments { get; set; }

        }
}

