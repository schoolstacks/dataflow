using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class LocationReference 
    {
        /// <summary>
        /// Location Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.
        /// </summary>
        public string classroomIdentificationCode { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related location resource.
        /// </summary>
        public Link link { get; set; }

        }
}

