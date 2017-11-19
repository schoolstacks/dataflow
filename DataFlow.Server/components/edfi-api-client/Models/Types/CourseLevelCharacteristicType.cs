using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Types 
{
    public class CourseLevelCharacteristicType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Code for CourseLevelCharacteristics type.
        /// </summary>
        public int? courseLevelCharacteristicTypeId { get; set; }

        /// <summary>
        /// Code for CourseLevelCharacteristics type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A shortened description for the course level characteristic type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

