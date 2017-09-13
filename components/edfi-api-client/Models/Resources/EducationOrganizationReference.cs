using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class EducationOrganizationReference 
    {
        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related educationOrganization resource.
        /// </summary>
        public Link link { get; set; }

        }
}

