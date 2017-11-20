using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class LearningStandardContentStandard 
    {
        /// <summary>
        /// A reference to the related EducationOrganization resource.
        /// </summary>
        public EducationOrganizationReference mandatingEducationOrganizationReference { get; set; }

        /// <summary>
        /// The name of the content standard, for example Common Core.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The version identifier for the content.
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// The public web site address (URL), file, or ftp locator.
        /// </summary>
        public string uri { get; set; }

        /// <summary>
        /// The date on which this content was first published.
        /// </summary>
        public DateTime? publicationDate { get; set; }

        /// <summary>
        /// The year at which this content was first published.
        /// </summary>
        public int? publicationYear { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string publicationStatusType { get; set; }

        /// <summary>
        /// The beginning of the period during which this learning standard document is intended for use.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The end of the period during which this learning standard document is intended for use.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// An unordered collection of learningStandardContentStandardAuthors.  The person or organization chiefly responsible for the intellectual content of the standard.
        /// </summary>
        public List<LearningStandardContentStandardAuthor> authors { get; set; }

        }
}

