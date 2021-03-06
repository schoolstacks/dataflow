namespace DataFlow.EdFi.Models.Types 
{
    public class TitleIPartASchoolDesignationType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for TitleIPartASchooldDesignation
        /// </summary>
        public int? titleIPartASchoolDesignationTypeId { get; set; }

        /// <summary>
        /// Code for TitleIPartASchooldDesignation type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the Title I Part A school designation type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

