namespace DataFlow.EdFi.Models.Types 
{
    public class EducationOrganizationCategoryType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for EducationOrganizationCategoryType
        /// </summary>
        public int? educationOrganizationCategoryTypeId { get; set; }

        /// <summary>
        /// The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Code for education organization category type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

