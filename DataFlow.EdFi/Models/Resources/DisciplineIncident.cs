using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class DisciplineIncident 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

        /// <summary>
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// A locally assigned unique identifier (within the school or school district) to identify each specific incident or occurrence. The same identifier should be used to document the entire incident even if it included multiple offenses and multiple offenders.
        /// </summary>
        public string incidentIdentifier { get; set; }

        /// <summary>
        /// The month, day, and year on which the DisciplineIncident occurred.
        /// </summary>
        public DateTime? incidentDate { get; set; }

        /// <summary>
        /// An indication of the time of day the incident took place.
        /// </summary>
        public string incidentTime { get; set; }

        /// <summary>
        /// Identifies where the incident occurred and whether or not it occurred on campus, for example:  On campus  Administrative offices area  Cafeteria area  Classroom  Hallway or stairs  ...
        /// </summary>
        public string incidentLocationType { get; set; }

        /// <summary>
        /// The description for an incident.
        /// </summary>
        public string incidentDescription { get; set; }

        /// <summary>
        /// Information on the type of individual who reported the incident. When known and/or if useful, use a more specific option code (e.g., "Counselor" rather than "Professional Staff"); for example:Student  Parent/guardian  Law enforcement officer  Nonschool personnel  Representative of visiting school  ...
        /// </summary>
        public string reporterDescriptionDescriptor { get; set; }

        /// <summary>
        /// Identifies the reporter of the incident by name.
        /// </summary>
        public string reporterName { get; set; }

        /// <summary>
        /// Indicator of whether the incident was reported to law enforcement.
        /// </summary>
        public bool? reportedToLawEnforcement { get; set; }

        /// <summary>
        /// The case number assigned to the incident by law enforcement or other organization.
        /// </summary>
        public string caseNumber { get; set; }

        /// <summary>
        /// The value of any quantifiable monetary loss directly resulting from the DisciplineIncident. Examples include the value of repairs necessitated by vandalism of a school facility, or the value of personnel resources used for repairs or consumed by the incident.
        /// </summary>
        public double? incidentCost { get; set; }

        /// <summary>
        /// An unordered collection of disciplineIncidentBehaviors.  The categories of behavior describing a discipline incident.
        /// </summary>
        public List<DisciplineIncidentBehavior> behaviors { get; set; }

        /// <summary>
        /// An unordered collection of disciplineIncidentWeapons.  Identifies the type of weapon used during an incident.
        /// </summary>
        public List<DisciplineIncidentWeapon> weapons { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

