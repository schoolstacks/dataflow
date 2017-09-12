using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class SchoolReference 
    {
        /// <summary>
        /// The identifier assigned to a school by the State Education Agency (SEA).
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related school resource.
        /// </summary>
        public Link link { get; set; }

        }
}

