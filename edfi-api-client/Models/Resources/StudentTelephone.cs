using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentTelephone 
    {
        /// <summary>
        /// Key for TelephoneNumber
        /// </summary>
        public string telephoneNumberType { get; set; }

        /// <summary>
        /// The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.
        /// </summary>
        public int? orderOfPriority { get; set; }

        /// <summary>
        /// An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.
        /// </summary>
        public bool? textMessageCapabilityIndicator { get; set; }

        /// <summary>
        /// The telephone number including the area code, and extension, if applicable.
        /// </summary>
        public string telephoneNumber { get; set; }

        }
}

