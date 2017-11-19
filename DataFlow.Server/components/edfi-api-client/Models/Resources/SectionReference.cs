using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class SectionReference 
    {
        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period
        /// </summary>
        public string classPeriodName { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.
        /// </summary>
        public string classroomIdentificationCode { get; set; }

        /// <summary>
        /// The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.
        /// </summary>
        public string localCourseCode { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string termDescriptor { get; set; }

        /// <summary>
        /// The identifier for the school year.
        /// </summary>
        public int? schoolYear { get; set; }

        /// <summary>
        /// A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.
        /// </summary>
        public string uniqueSectionCode { get; set; }

        /// <summary>
        /// When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.
        /// </summary>
        public int? sequenceOfCourse { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related section resource.
        /// </summary>
        public Link link { get; set; }

        }
}

