using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentDisciplineIncidentAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related DisciplineIncident resource.
        /// </summary>
        public DisciplineIncidentReference disciplineIncidentReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// The role or type of participation of a student in a discipline incident; for example:  Victim  Perpetrator  Witness  Reporter
        /// </summary>
        public string studentParticipationCodeType { get; set; }

        /// <summary>
        /// An unordered collection of studentDisciplineIncidentAssociationBehaviors.  
        /// </summary>
        public List<StudentDisciplineIncidentAssociationBehavior> behaviors { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

