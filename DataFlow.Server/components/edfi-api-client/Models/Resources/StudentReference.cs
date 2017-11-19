using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentReference 
    {
        /// <summary>
        /// A unique alpha-numeric code assigned to a student.
        /// </summary>
        public string studentUniqueId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related student resource.
        /// </summary>
        public Link link { get; set; }

        }
}

