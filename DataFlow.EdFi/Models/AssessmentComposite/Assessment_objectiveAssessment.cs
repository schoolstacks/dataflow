using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class Assessment_objectiveAssessment 
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.
        /// </summary>
        [JsonProperty(PropertyName = "identificationCode")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter object assessment(s) separated by new lines.")]
        [Display(Name = "Objective Assessments")]
        public string IdentificationCode { get; set; }

        /// <summary>
        /// A detailed description of the entity.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The maximum raw score achievable across all assessment items that are correct and scored at the maximum.
        /// </summary>
        public int? maxRawScore { get; set; }

        /// <summary>
        /// Reflects the common nomenclature for an element.
        /// </summary>
        public string nomenclature { get; set; }

        /// <summary>
        /// The percentage of the Assessment that tests this objective.
        /// </summary>
        public double? percentOfAssessment { get; set; }

        /// <summary>
        /// An unordered collection of objectiveAssessmentPerformanceLevels.  
        /// </summary>
        public List<Assessment_objectiveAssessment_objectiveAssessmentPerformanceLevel> objectiveAssessmentPerformanceLevels { get; set; }

        /// <summary>
        /// An unordered collection of objectiveAssessmentLearningObjectives.  
        /// </summary>
        public List<Assessment_objectiveAssessment_objectiveAssessmentLearningObjective> learningObjectives { get; set; }

        /// <summary>
        /// An unordered collection of objectiveAssessmentLearningStandards.  
        /// </summary>
        public List<Assessment_objectiveAssessment_objectiveAssessmentLearningStandard> learningStandards { get; set; }

        }
}

