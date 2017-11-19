using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StaffReference 
    {
        /// <summary>
        /// A unique alpha-numeric code assigned to a staff.
        /// </summary>
        public string staffUniqueId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related staff resource.
        /// </summary>
        public Link link { get; set; }

        }
}

