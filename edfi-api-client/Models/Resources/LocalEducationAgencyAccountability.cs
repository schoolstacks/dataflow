using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class LocalEducationAgencyAccountability 
    {
        /// <summary>
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference schoolYearTypeReference { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string gunFreeSchoolsActReportingStatusType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string schoolChoiceImplementStatusType { get; set; }

        }
}

