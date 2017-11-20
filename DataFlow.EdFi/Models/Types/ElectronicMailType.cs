namespace DataFlow.EdFi.Models.Types 
{
    public class ElectronicMailType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for ElectronicMail
        /// </summary>
        public int? electronicMailTypeId { get; set; }

        /// <summary>
        /// Code for ElectronicMail type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the electronic mail type.  
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

