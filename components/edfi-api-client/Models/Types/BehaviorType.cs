using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Types 
{
    public class BehaviorType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for BehaviorCategoryType.
        /// </summary>
        public int? behaviorTypeId { get; set; }

        /// <summary>
        /// Code for BehaviorCategoryType.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description for BehaviorCategory type.
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

