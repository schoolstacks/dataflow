using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class EducationOrganizationInterventionPrescriptionAssociation 
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
        /// A reference to the related InterventionPrescription resource.
        /// </summary>
        public InterventionPrescriptionReference interventionPrescriptionReference { get; set; }

        /// <summary>
        /// The begin date of the period during which the InterventionPrescription is available.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The end date of the period during which the InterventionPrescription is available.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

