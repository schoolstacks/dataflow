using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class InterventionStudy 
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
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string identificationCode { get; set; }

        /// <summary>
        /// The number of participants observed in the study.
        /// </summary>
        public int? participants { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string deliveryMethodType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string interventionClassType { get; set; }

        /// <summary>
        /// An unordered collection of interventionStudyAppropriateGradeLevels.  Grade levels participating in this study.
        /// </summary>
        public List<InterventionStudyAppropriateGradeLevel> appropriateGradeLevels { get; set; }

        /// <summary>
        /// An unordered collection of interventionStudyAppropriateSexes.  Genders participating in this study-if omitted, considered to be all.
        /// </summary>
        public List<InterventionStudyAppropriateSex> appropriateSexes { get; set; }

        /// <summary>
        /// An unordered collection of interventionStudyEducationContents.  Reference to any published papers, reports or other documents about this intervention study.
        /// </summary>
        public List<InterventionStudyEducationContent> educationContents { get; set; }

        /// <summary>
        /// An unordered collection of interventionStudyInterventionEffectivenesses.  Measurement of the effectiveness of the intervention per diagnosis.
        /// </summary>
        public List<InterventionStudyInterventionEffectiveness> interventionEffectivenesses { get; set; }

        /// <summary>
        /// An unordered collection of interventionStudyLearningResourceMetadataURIs.  Reference to any published papers, reports or other documents about this intervention study.
        /// </summary>
        public List<InterventionStudyLearningResourceMetadataURI> learningResourceMetadataURIs { get; set; }

        /// <summary>
        /// An unordered collection of interventionStudyPopulationServeds.  A subset of students that are the focus of the intervention.
        /// </summary>
        public List<InterventionStudyPopulationServed> populationServeds { get; set; }

        /// <summary>
        /// An unordered collection of interventionStudyStateAbbreviations.  The abbreviation for the state (within the United States) or outlying area in which the school system that the participants of the study are considered to be a part of is located.
        /// </summary>
        public List<InterventionStudyStateAbbreviation> stateAbbreviations { get; set; }

        /// <summary>
        /// An unordered collection of interventionStudyURIs.  Reference to any published papers, reports or other documents about this intervention study.
        /// </summary>
        public List<InterventionStudyURI> uris { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

