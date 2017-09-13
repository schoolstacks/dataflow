using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class InterventionPrescription 
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
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string identificationCode { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string interventionClassType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string deliveryMethodType { get; set; }

        /// <summary>
        /// An unordered collection of interventionPrescriptionAppropriateGradeLevels.  Grade levels for the prescribed intervention-if omitted, considered generally applicable.
        /// </summary>
        public List<InterventionPrescriptionAppropriateGradeLevel> appropriateGradeLevels { get; set; }

        /// <summary>
        /// An unordered collection of interventionPrescriptionAppropriateSexes.  Gender(s) for which the intervention prescription is appropriate.
        /// </summary>
        public List<InterventionPrescriptionAppropriateSex> appropriateSexes { get; set; }

        /// <summary>
        /// An unordered collection of interventionPrescriptionDiagnoses.  Targeted purpose of the intervention (e.g., attendance issue, dropout risk).
        /// </summary>
        public List<InterventionPrescriptionDiagnosis> diagnoses { get; set; }

        /// <summary>
        /// An unordered collection of interventionPrescriptionEducationContents.  Resources related to or used in this intervention prescription, including any documentation around the intervention prescription itself. Since an intervention prescription is intended to be a published intervention, an intervention prescription should have at least one such resource.
        /// </summary>
        public List<InterventionPrescriptionEducationContent> educationContents { get; set; }

        /// <summary>
        /// An unordered collection of interventionPrescriptionLearningResourceMetadataURIs.  Resources related to or used in this intervention prescription, including any documentation around the intervention prescription itself. Since an intervention prescription is intended to be a published intervention, an intervention prescription should have at least one such resource.
        /// </summary>
        public List<InterventionPrescriptionLearningResourceMetadataURI> learningResourceMetadataURIs { get; set; }

        /// <summary>
        /// An unordered collection of interventionPrescriptionPopulationServeds.  A subset of students that are the focus of the intervention.
        /// </summary>
        public List<InterventionPrescriptionPopulationServed> populationServeds { get; set; }

        /// <summary>
        /// An unordered collection of interventionPrescriptionURIs.  Resources related to or used in this intervention prescription, including any documentation around the intervention prescription itself. Since an intervention prescription is intended to be a published intervention, an intervention prescription should have at least one such resource.
        /// </summary>
        public List<InterventionPrescriptionURI> uris { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

