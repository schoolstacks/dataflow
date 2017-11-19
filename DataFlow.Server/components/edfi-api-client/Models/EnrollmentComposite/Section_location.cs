using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.EnrollmentComposite 
{
    public class Section_location 
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Location Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.
        /// </summary>
        public string classroomIdentificationCode { get; set; }

        }
}

