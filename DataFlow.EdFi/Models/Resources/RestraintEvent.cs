using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class RestraintEvent 
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
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a restraint event by a school, school system, a state, or other agency or entity.
        /// </summary>
        public string identifier { get; set; }

        /// <summary>
        /// Month, day, and year of the RestraintEvent.
        /// </summary>
        public DateTime? eventDate { get; set; }

        /// <summary>
        /// The setting where the restrint was exercised..
        /// </summary>
        public string educationalEnvironmentType { get; set; }

        /// <summary>
        /// An unordered collection of restraintEventPrograms.  The Special Education program associated with the restraint event.
        /// </summary>
        public List<RestraintEventProgram> programs { get; set; }

        /// <summary>
        /// An unordered collection of restraintEventReasons.  The items of categorization of the circumstances or reasons for the restraint.
        /// </summary>
        public List<RestraintEventReason> reasons { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

