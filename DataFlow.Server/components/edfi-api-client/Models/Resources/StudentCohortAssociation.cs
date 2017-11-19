using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentCohortAssociation 
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
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// The month, day, and year on which the Student was first identified as part of the Cohort.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The month, day, and year on which the Student was removed as part of the Cohort.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// An unordered collection of studentCohortAssociationSections.  The cohort representing the subdivision of students within one or more sections. For example, a group of students may be given additional instruction and tracked as a cohort.
        /// </summary>
        public List<StudentCohortAssociationSection> sections { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

