using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class EducationServiceCenterReference 
    {
        /// <summary>
        /// The identifier assigned to an education service center by the State Education Agency (SEA).
        /// </summary>
        public int? educationServiceCenterId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related educationServiceCenter resource.
        /// </summary>
        public Link link { get; set; }

        }
}

