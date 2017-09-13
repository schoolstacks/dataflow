using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class EducationOrganizationNetworkReference 
    {
        /// <summary>
        /// A unique number or alphanumeric code assigned to a network of education organizations.
        /// </summary>
        public int? educationOrganizationNetworkId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related educationOrganizationNetwork resource.
        /// </summary>
        public Link link { get; set; }

        }
}

