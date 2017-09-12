using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class ContractedStaff 
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
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// The date of the reported contracted staff element.
        /// </summary>
        public DateTime? asOfDate { get; set; }

        /// <summary>
        /// Current balance (amount paid to contractor) for account for the fiscal year.
        /// </summary>
        public double? amountToDate { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

