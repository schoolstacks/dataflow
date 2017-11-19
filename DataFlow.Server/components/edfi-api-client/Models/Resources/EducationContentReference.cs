using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class EducationContentReference 
    {
        /// <summary>
        /// The identifier of the content standard.
        /// </summary>
        public string contentIdentifier { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related educationContent resource.
        /// </summary>
        public Link link { get; set; }

        }
}

