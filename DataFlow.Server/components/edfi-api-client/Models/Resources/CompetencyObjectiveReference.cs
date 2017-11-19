using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class CompetencyObjectiveReference 
    {
        /// <summary>
        /// The designated title of the learning objective.
        /// </summary>
        public string objective { get; set; }

        /// <summary>
        /// The grade level for which the competency objective is targeted,
        /// </summary>
        public string objectiveGradeLevelDescriptor { get; set; }

        /// <summary>
        /// The education organization that defined the competency objective
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related competencyObjective resource.
        /// </summary>
        public Link link { get; set; }

        }
}

