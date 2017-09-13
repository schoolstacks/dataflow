using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class LearningStandardReference 
    {
        /// <summary>
        /// A unique number or alphanumeric code assigned to a Learning Standard.
        /// </summary>
        public string learningStandardId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related learningStandard resource.
        /// </summary>
        public Link link { get; set; }

        }
}

