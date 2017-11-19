using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentSectionAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Section resource.
        /// </summary>
        public SectionReference sectionReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// Month, day, and year of the Student's entry or assignment to the Section.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// Month, day, and year of the withdrawal or exit of the Student from the Section.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Indicates the Section is the student's homeroom. Homeroom period may the convention for taking daily attendance.
        /// </summary>
        public bool? homeroomIndicator { get; set; }

        /// <summary>
        /// An indication as to whether a student has previously taken a given course.  NEDM: Repeat Identifier  Repeated, counted in grade point average  Repeated, not counted in grade point average  Not repeated  Other
        /// </summary>
        public string repeatIdentifierType { get; set; }

        /// <summary>
        /// Indicates that the student-section combination is excluded from calculation of value-added or growth attribution calculations used for a particular teacher evaluation.
        /// </summary>
        public bool? teacherStudentDataLinkExclusion { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

