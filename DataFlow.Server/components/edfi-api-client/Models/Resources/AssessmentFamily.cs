using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class AssessmentFamily 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related AssessmentFamily resource.
        /// </summary>
        public AssessmentFamilyReference parentAssessmentFamilyReference { get; set; }

        /// <summary>
        /// The title or name of the assessment family.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string assessmentCategoryDescriptor { get; set; }

        /// <summary>
        /// Key for AcademicSubject
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// Key for GradeLevel
        /// </summary>
        public string assessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// Key for GradeLevel
        /// </summary>
        public string lowestAssessedGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The version identifier for the assessment.
        /// </summary>
        public int? version { get; set; }

        /// <summary>
        /// The month, day, and year that the conceptual design for the AssessmentFamily was most recently revised substantially.
        /// </summary>
        public DateTime? revisionDate { get; set; }

        /// <summary>
        /// Reflects the common nomenclature for an element.
        /// </summary>
        public string nomenclature { get; set; }

        /// <summary>
        /// Namespace for the Assessments in this AssessmentFamily.
        /// </summary>
        public string @namespace { get; set; }

        /// <summary>
        /// An indication as to whether an assessment conforms to a standard (e.g., local standard, statewide standard, regional standard, association standard).
        /// </summary>
        public AssessmentFamilyContentStandard contentStandard { get; set; }

        /// <summary>
        /// An unordered collection of assessmentFamilyAssessmentPeriods.  The periods or windows defined in which an assessment is supposed to be administered.
        /// </summary>
        public List<AssessmentFamilyAssessmentPeriod> assessmentPeriods { get; set; }

        /// <summary>
        /// An unordered collection of assessmentFamilyIdentificationCodes.  A unique number or alphanumeric code assigned to an assessment family by a school, school system, a state, or other agency or entity.
        /// </summary>
        public List<AssessmentFamilyIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of assessmentFamilyLanguages.  An indication of the languages in which the Assessment Family is designed.
        /// </summary>
        public List<AssessmentFamilyLanguage> languages { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

