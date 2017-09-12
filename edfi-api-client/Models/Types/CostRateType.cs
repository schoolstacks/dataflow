using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Types 
{
    public class CostRateType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public int? costRateTypeId { get; set; }

        /// <summary>
        /// The rate by which the cost applies, e.g. Flat Fee, Per Student
        /// </summary>
        public string shortDescription { get; set; }

        /// <summary>
        /// Code for cost rate type.
        /// </summary>
        public string codeValue { get; set; }

        /// <summary>
        /// Description of cost rate type.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

