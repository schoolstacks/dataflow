namespace DataFlow.EdFi.Models.Types 
{
    public class LimitedEnglishProficiencyType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for LimitedEnglishProficiency
        /// </summary>
        public int? limitedEnglishProficiencyTypeId { get; set; }

        /// <summary>
        /// Code for LimitedEnglishProficiency type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the limited English proficiency type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

