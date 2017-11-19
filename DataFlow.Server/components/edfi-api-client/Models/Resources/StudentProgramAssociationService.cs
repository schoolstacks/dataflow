using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentProgramAssociationService 
    {
        /// <summary>
        /// The ID of the Service Descriptor
        /// </summary>
        public string serviceDescriptor { get; set; }

        /// <summary>
        /// True if service is a primary service.
        /// </summary>
        public bool? primaryIndicator { get; set; }

        /// <summary>
        /// First date the Student was in this option for the current school year.
        /// </summary>
        public DateTime? serviceBeginDate { get; set; }

        /// <summary>
        /// Last date the Student was in this option for the current school year.
        /// </summary>
        public DateTime? serviceEndDate { get; set; }

        }
}

