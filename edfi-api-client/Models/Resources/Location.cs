using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class Location 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.
        /// </summary>
        public string classroomIdentificationCode { get; set; }

        /// <summary>
        /// The most number of seats the class can maintain.
        /// </summary>
        public int? maximumNumberOfSeats { get; set; }

        /// <summary>
        /// The number of seats that is most favorable to the class.
        /// </summary>
        public int? optimalNumberOfSeats { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

