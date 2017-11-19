using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class AssessmentFamilyReference 
    {
        /// <summary>
        /// The title or name of the assessment family.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related assessmentFamily resource.
        /// </summary>
        public Link link { get; set; }

        }
}

