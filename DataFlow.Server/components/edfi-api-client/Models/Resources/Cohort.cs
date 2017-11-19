using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class Cohort 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related EducationOrganization resource.
        /// </summary>
        public EducationOrganizationReference educationOrganizationReference { get; set; }

        /// <summary>
        /// The name or ID for the cohort.
        /// </summary>
        public string identifier { get; set; }

        /// <summary>
        /// The description of he cohort and its purpose.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// The type of the cohort (academic intervention, attendance intervention, discipline intervention, breakout session, etc.).
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The scope of cohort (e.g., campus, district, classroom).
        /// </summary>
        public string scopeType { get; set; }

        /// <summary>
        /// The subject for an academic intervention (e.g., science, mathematics).
        /// </summary>
        public string academicSubjectDescriptor { get; set; }

        /// <summary>
        /// An unordered collection of cohortPrograms.  The optional program associated with this cohort (e.g., Special Education).
        /// </summary>
        public List<CohortProgram> programs { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

