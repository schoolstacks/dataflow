namespace DataFlow.EdFi.Models.Types 
{
    public class SchoolFoodServicesEligibilityType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for SchoolFoodServicesEligibility
        /// </summary>
        public int? schoolFoodServicesEligibilityTypeId { get; set; }

        /// <summary>
        /// Code for SchoolFoodServicesEligibility type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description for SchoolFoodServicesEligibility type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the descriptor.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

