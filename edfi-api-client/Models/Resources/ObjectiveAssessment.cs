using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class ObjectiveAssessment 
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
        /// A reference to the related ObjectiveAssessment resource.
        /// </summary>
        public ObjectiveAssessmentReference parentObjectiveAssessmentReference { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.
        /// </summary>
        public string identificationCode { get; set; }

        /// <summary>
        /// The maximum raw score achievable across all assessment items that are correct and scored at the maximum.
        /// </summary>
        public int? maxRawScore { get; set; }

        /// <summary>
        /// The percentage of the Assessment that tests this objective.
        /// </summary>
        public double? percentOfAssessment { get; set; }

        /// <summary>
        /// Reflects the common nomenclature for an element.
        /// </summary>
        public string nomenclature { get; set; }

        /// <summary>
        /// A detailed description of the entity.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// An unordered collection of objectiveAssessmentAssessmentItems.  References individual test items, if appropriate.
        /// </summary>
        public List<ObjectiveAssessmentAssessmentItem> assessmentItems { get; set; }

        /// <summary>
        /// An unordered collection of objectiveAssessmentLearningObjectives.  References the Learning Objective(s) the Objective Assessment tests.
        /// </summary>
        public List<ObjectiveAssessmentLearningObjective> learningObjectives { get; set; }

        /// <summary>
        /// An unordered collection of objectiveAssessmentLearningStandards.  Learning Standard tested by this objective assessment.
        /// </summary>
        public List<ObjectiveAssessmentLearningStandard> learningStandards { get; set; }

        /// <summary>
        /// An unordered collection of objectiveAssessmentPerformanceLevels.  Definition of the performance levels and the associated cut scores. Three styles are supported:  1. Specification of performance level by minimum and maximum score    2. Specification of performance level by cut score, using only minimum score    3. Specification of performance level without any mapping to scores.
        /// </summary>
        public List<ObjectiveAssessmentPerformanceLevel> performanceLevels { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

