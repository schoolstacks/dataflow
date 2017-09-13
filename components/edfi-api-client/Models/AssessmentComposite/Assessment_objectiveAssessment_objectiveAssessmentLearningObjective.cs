using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.AssessmentComposite 
{
    public class Assessment_objectiveAssessment_objectiveAssessmentLearningObjective 
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The designated title of the learning objective.
        /// </summary>
        public string objective { get; set; }

        /// <summary>
        /// The grade level for which the learning objective is targeted,
        /// </summary>
        public string objectiveGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The grade level for which the learning objective is targeted,
        /// </summary>
        public string objectiveGradeLevelType { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.
        /// </summary>
        public string academicSubjectType { get; set; }

        /// <summary>
        /// A detailed description of the entity.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).
        /// </summary>
        public string learningObjectiveId { get; set; }

        /// <summary>
        /// Reflects the common nomenclature for an element.
        /// </summary>
        public string nomenclature { get; set; }

        /// <summary>
        /// One or more statements that describes the criteria used by teachers and students to check for attainment of a learning objective. This criteria gives clear indications as to the degree to which learning is moving through the Zone or Proximal Development toward independent achievement of the LearningObjective.
        /// </summary>
        public string successCriteria { get; set; }

        /// <summary>
        /// An unordered collection of learningObjectiveLearningStandards.  
        /// </summary>
        public List<Assessment_objectiveAssessment_objectiveAssessmentLearningObjective_learningObjectiveLearningStandard> learningStandards { get; set; }

        }
}

