using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.EnrollmentComposite 
{
    public class Section_classPeriod 
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period
        /// </summary>
        public string name { get; set; }

        }
}

