using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class Budget 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Account resource.
        /// </summary>
        public AccountReference accountReference { get; set; }

        /// <summary>
        /// The date of the reported budget element.
        /// </summary>
        public DateTime? asOfDate { get; set; }

        /// <summary>
        /// Amount budgeted for the account for this fiscal year.
        /// </summary>
        public double? amount { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

