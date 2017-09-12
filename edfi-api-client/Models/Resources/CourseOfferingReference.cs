using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class CourseOfferingReference 
    {
        /// <summary>
        /// The local code assigned by the LEA that identifies the organization of subject matter and related learning experiences provided for the instruction of students.
        /// </summary>
        public string localCourseCode { get; set; }

        /// <summary>
        /// School Identity Column  
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// The identifier for the school year.
        /// </summary>
        public int? schoolYear { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string termDescriptor { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related courseOffering resource.
        /// </summary>
        public Link link { get; set; }

        }
}

