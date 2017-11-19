using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Types 
{
    public class SchoolYearType 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Key for School
        /// </summary>
        public int? schoolYear { get; set; }

        /// <summary>
        /// Description for SchoolYear type.
        /// </summary>
        public string schoolYearDescription { get; set; }

        /// <summary>
        /// Code for SchoolYear type.
        /// </summary>
        public bool? currentSchoolYear { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

