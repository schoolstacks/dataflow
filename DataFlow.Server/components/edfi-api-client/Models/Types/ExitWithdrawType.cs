using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Types 
{
    public class ExitWithdrawType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for ExitWithdraw
        /// </summary>
        public int? exitWithdrawTypeId { get; set; }

        /// <summary>
        /// Code for ExitWithdraw type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description for ExitWithdraw type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Short description for exit withdraw type.
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

