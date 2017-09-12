using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentDisciplineIncidentAssociationBehavior 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string behaviorDescriptor { get; set; }

        /// <summary>
        /// Specifies a more granular level of detail of a behavior involved in the incident.
        /// </summary>
        public string behaviorDetailedDescription { get; set; }

        }
}

