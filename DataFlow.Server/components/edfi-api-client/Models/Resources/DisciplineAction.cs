using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class DisciplineAction 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference assignmentSchoolReference { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference responsibilitySchoolReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// Identifier assigned by the education organization to the discipline action.
        /// </summary>
        public string identifier { get; set; }

        /// <summary>
        /// The date of the DisciplineAction.
        /// </summary>
        public DateTime? disciplineDate { get; set; }

        /// <summary>
        /// The length of time in school days for the Discipline Action (e.g. removal, detention), if applicable.
        /// </summary>
        public int? length { get; set; }

        /// <summary>
        /// Indicates the actual length in school days of a student's disciplinary assignment.
        /// </summary>
        public int? actualDisciplineActionLength { get; set; }

        /// <summary>
        /// Key for DisciplineActionLengthDifferenceReason
        /// </summary>
        public string lengthDifferenceReasonType { get; set; }

        /// <summary>
        /// An indication of whether or not this disciplinary action taken against a student was imposed as a consequence of state or local zero tolerance policies.
        /// </summary>
        public bool? relatedToZeroTolerancePolicy { get; set; }

        /// <summary>
        /// An unordered collection of disciplineActionDisciplines.  Type of action, such as removal from the classroom, used to discipline the student involved as a perpetrator in a discipline incident.
        /// </summary>
        public List<DisciplineActionDiscipline> disciplines { get; set; }

        /// <summary>
        /// An unordered collection of disciplineActionDisciplineIncidents.  
        /// </summary>
        public List<DisciplineActionDisciplineIncident> disciplineIncidents { get; set; }

        /// <summary>
        /// An unordered collection of disciplineActionStaffs.  The staff responsible for enforcing the discipline action.
        /// </summary>
        public List<DisciplineActionStaff> staffs { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

