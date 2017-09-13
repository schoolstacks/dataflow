using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class FeederSchoolAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference feederSchoolReference { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

        /// <summary>
        /// The month, day, and year of the first day of the feeder school association.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The month, day, and year of the last day of the feeder school association.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Describes the relationship from the feeder school to the receiving school, for example by program emphasis, such as special education, language immersion, science, or performing art.
        /// </summary>
        public string feederRelationshipDescription { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

