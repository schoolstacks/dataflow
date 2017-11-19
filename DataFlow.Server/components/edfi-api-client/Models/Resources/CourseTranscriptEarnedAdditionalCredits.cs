using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class CourseTranscriptEarnedAdditionalCredits 
    {
        /// <summary>
        /// The type of credits awarded or earned for the course.
        /// </summary>
        public string additionalCreditType { get; set; }

        /// <summary>
        /// The number of credits awarded or earned for the course.
        /// </summary>
        public double? credits { get; set; }

        }
}

