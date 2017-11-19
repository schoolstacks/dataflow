using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentDisability 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string disabilityDescriptor { get; set; }

        /// <summary>
        /// A description of the disability diagnosis.
        /// </summary>
        public string disabilityDiagnosis { get; set; }

        /// <summary>
        /// The order by severity of student's disabilities: 1- Primary, 2 - Secondary, 3 - Tertiary, etc.
        /// </summary>
        public int? orderOfDisability { get; set; }

        /// <summary>
        /// Key for Disability Determination Source Type
        /// </summary>
        public string disabilityDeterminationSourceType { get; set; }

        }
}

