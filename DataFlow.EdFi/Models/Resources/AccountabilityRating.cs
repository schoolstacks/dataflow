using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class AccountabilityRating 
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
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference schoolYearTypeReference { get; set; }

        /// <summary>
        /// The title of the rating (e.g., School Rating, Safety Score).
        /// </summary>
        public string ratingTitle { get; set; }

        /// <summary>
        /// An accountability rating level, designation, or assessment.
        /// </summary>
        public string rating { get; set; }

        /// <summary>
        /// The date the rating was awarded.
        /// </summary>
        public DateTime? ratingDate { get; set; }

        /// <summary>
        /// The organization assigning the accountability rating.
        /// </summary>
        public string ratingOrganization { get; set; }

        /// <summary>
        /// The rating program (e.g., NCLB).
        /// </summary>
        public string ratingProgram { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

