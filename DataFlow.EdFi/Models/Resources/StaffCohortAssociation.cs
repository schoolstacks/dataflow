using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StaffCohortAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Cohort resource.
        /// </summary>
        public CohortReference cohortReference { get; set; }

        /// <summary>
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// Start date for the association of staff to this cohort.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// End date for the association of staff to this cohort.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Indicator of whether the staff has access to the student records of the cohort per district interpretation of FERPA and other privacy laws, regulations, and policies.
        /// </summary>
        public bool? studentRecordAccess { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

