using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentInterventionAssociation 
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
        /// A reference to the related Intervention resource.
        /// </summary>
        public InterventionReference interventionReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// A statement provided by the teacher that provides information in addition to the grade or assessment score.
        /// </summary>
        public string diagnosticStatement { get; set; }

        /// <summary>
        /// An unordered collection of studentInterventionAssociationInterventionEffectivenesses.  
        /// </summary>
        public List<StudentInterventionAssociationInterventionEffectiveness> interventionEffectivenesses { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

