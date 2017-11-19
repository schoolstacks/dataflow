using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class SchoolYearTypeReference 
    {
        /// <summary>
        /// Key for School
        /// </summary>
        public int? schoolYear { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related schoolYearType resource.
        /// </summary>
        public Link link { get; set; }

        }
}

