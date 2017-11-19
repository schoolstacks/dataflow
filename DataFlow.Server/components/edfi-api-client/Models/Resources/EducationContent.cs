using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class EducationContent 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related LearningStandard resource.
        /// </summary>
        public LearningStandardReference learningStandardReference { get; set; }

        /// <summary>
        /// The identifier of the content standard.
        /// </summary>
        public string contentIdentifier { get; set; }

        /// <summary>
        /// The public web site address (URL), file, or ftp locator.
        /// </summary>
        public string learningResourceMetadataURI { get; set; }

        /// <summary>
        /// A shortened description for reference.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A detailed description of the entity.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Indicates whether there are additional un-named authors. In a research report, this is often marked by the abbreviation "et al".
        /// </summary>
        public bool? additionalAuthorsIndicator { get; set; }

        /// <summary>
        /// The organization credited with publishing the resource.
        /// </summary>
        public string publisher { get; set; }

        /// <summary>
        /// Approximate or typical time it takes to work with or through this learning resource for the typical intended target audience.
        /// </summary>
        public string timeRequired { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string interactivityStyleType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string contentClassType { get; set; }

        /// <summary>
        /// The URL where the owner specifies permissions for using the resource.
        /// </summary>
        public string useRightsURL { get; set; }

        /// <summary>
        /// The date on which this content was first published.
        /// </summary>
        public DateTime? publicationDate { get; set; }

        /// <summary>
        /// The year at which this content was first published.
        /// </summary>
        public int? publicationYear { get; set; }

        /// <summary>
        /// The version identifier for the content.
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// An amount that has to be paid or spent to buy or obtain the EducationContent.
        /// </summary>
        public double? cost { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string costRateType { get; set; }

        /// <summary>
        /// Namespace for the EducationContent.
        /// </summary>
        public string @namespace { get; set; }

        /// <summary>
        /// An unordered collection of educationContentAppropriateGradeLevels.  Grade levels for which this education content is applicable-if omitted, considered generally applicable.
        /// </summary>
        public List<EducationContentAppropriateGradeLevel> appropriateGradeLevels { get; set; }

        /// <summary>
        /// An unordered collection of educationContentAppropriateSexes.  Genders for which this education content is applicable-if omitted, considered generally applicable.
        /// </summary>
        public List<EducationContentAppropriateSex> appropriateSexes { get; set; }

        /// <summary>
        /// An unordered collection of educationContentAuthors.  The individual credited with the creation of the resource.
        /// </summary>
        public List<EducationContentAuthor> authors { get; set; }

        /// <summary>
        /// An unordered collection of educationContentDerivativeSourceEducationContents.  A reference to the Education Content from which this Education Content was derived.
        /// </summary>
        public List<EducationContentDerivativeSourceEducationContent> derivativeSourceEducationContents { get; set; }

        /// <summary>
        /// An unordered collection of educationContentDerivativeSourceLearningResourceMetadataURIs.  A reference to the Learning Resource Metadata URI from which this Education Content was derived.
        /// </summary>
        public List<EducationContentDerivativeSourceLearningResourceMetadataURI> derivativeSourceLearningResourceMetadataURIs { get; set; }

        /// <summary>
        /// An unordered collection of educationContentDerivativeSourceURIs.  A reference to the URI from which this Education Content was derived.
        /// </summary>
        public List<EducationContentDerivativeSourceURI> derivativeSourceURIs { get; set; }

        /// <summary>
        /// An unordered collection of educationContentLanguages.  An indication of the languages in which the Education Content is designed.
        /// </summary>
        public List<EducationContentLanguage> languages { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

