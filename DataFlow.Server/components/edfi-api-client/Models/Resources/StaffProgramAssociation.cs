using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StaffProgramAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Program resource.
        /// </summary>
        public ProgramReference programReference { get; set; }

        /// <summary>
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// Start date for the association of staff to this program.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// End date for the association of staff to this program.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Indicator of whether the staff has access to the student records of the program per district interpretation of FERPA and other privacy laws, regulations, and policies.
        /// </summary>
        public bool? studentRecordAccess { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

