using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class InterventionPrescriptionReference 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string identificationCode { get; set; }

        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related interventionPrescription resource.
        /// </summary>
        public Link link { get; set; }

        }
}

