using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class PostSecondaryEvent 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// The postsecondary event that is logged (e.g., FAFSA application, college application, college acceptance)
        /// </summary>
        public string categoryType { get; set; }

        /// <summary>
        /// The date the event occurred or was recorded.
        /// </summary>
        public DateTime? eventDate { get; set; }

        /// <summary>
        /// An organization that provides educational programs for individuals who have completed or otherwise left educational programs in secondary school(s).
        /// </summary>
        public PostSecondaryEventPostSecondaryInstitution postSecondaryInstitution { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

