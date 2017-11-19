using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Types 
{
    public class GradeLevelType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for GradeLevel
        /// </summary>
        public int? gradeLevelTypeId { get; set; }

        /// <summary>
        /// Code for GradeLevel type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Short description for grade level type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// Description for GradeLevel type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

