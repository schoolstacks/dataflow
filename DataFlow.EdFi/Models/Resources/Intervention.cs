using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class Intervention 
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
        public string classType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string deliveryMethodType { get; set; }

        /// <summary>
        /// The start date for the intervention implementation.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The end date for the intervention implementation.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// An unordered collection of interventionAppropriateGradeLevels.  Grade levels for the intervention.
        /// </summary>
        public List<InterventionAppropriateGradeLevel> appropriateGradeLevels { get; set; }

        /// <summary>
        /// An unordered collection of interventionAppropriateSexes.  Gender(s) for which the intervention is appropriate.
        /// </summary>
        public List<InterventionAppropriateSex> appropriateSexes { get; set; }

        /// <summary>
        /// An unordered collection of interventionDiagnoses.  Targeted purpose of the intervention (e.g., attendance issue, dropout risk).
        /// </summary>
        public List<InterventionDiagnosis> diagnoses { get; set; }

        /// <summary>
        /// An unordered collection of interventionEducationContents.  Resources related to or used in this intervention, including any documentation around the intervention prescription itself. Since an intervention prescription is intended to be a published intervention, an intervention prescription should have at least one such resource.
        /// </summary>
        public List<InterventionEducationContent> educationContents { get; set; }

        /// <summary>
        /// An unordered collection of interventionInterventionPrescriptions.  The reference to the intervention prescription being followed in this intervention implementation.
        /// </summary>
        public List<InterventionInterventionPrescription> interventionPrescriptions { get; set; }

        /// <summary>
        /// An unordered collection of interventionLearningResourceMetadataURIs.  Resources related to or used in this intervention, including any documentation around the intervention prescription itself. Since an intervention prescription is intended to be a published intervention, an intervention prescription should have at least one such resource.
        /// </summary>
        public List<InterventionLearningResourceMetadataURI> learningResourceMetadataURIs { get; set; }

        /// <summary>
        /// An unordered collection of interventionMeetingTimes.  The times at which this intervention is scheduled to meet.
        /// </summary>
        public List<InterventionMeetingTime> meetingTimes { get; set; }

        /// <summary>
        /// An unordered collection of interventionPopulationServeds.  A subset of students that are the focus of the intervention. 
        /// </summary>
        public List<InterventionPopulationServed> populationServeds { get; set; }

        /// <summary>
        /// An unordered collection of interventionStaffs.  Staff member associated with the intervention.
        /// </summary>
        public List<InterventionStaff> staffs { get; set; }

        /// <summary>
        /// An unordered collection of interventionURIs.  Resources related to or used in this intervention, including any documentation around the intervention prescription itself. Since an intervention prescription is intended to be a published intervention, an intervention prescription should have at least one such resource.
        /// </summary>
        public List<InterventionURI> uris { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

