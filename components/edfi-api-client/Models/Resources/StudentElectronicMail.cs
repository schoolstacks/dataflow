using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentElectronicMail 
    {
        /// <summary>
        /// Key for ElectronicMail
        /// </summary>
        public string electronicMailType { get; set; }

        /// <summary>
        /// The electronic mail (e-mail) address listed for an individual or organization.
        /// </summary>
        public string electronicMailAddress { get; set; }

        /// <summary>
        /// An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.
        /// </summary>
        public bool? primaryEmailAddressIndicator { get; set; }

        }
}

