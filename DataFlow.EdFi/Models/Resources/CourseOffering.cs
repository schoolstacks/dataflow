using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class CourseOffering 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related Course resource.
        /// </summary>
        public CourseReference courseReference { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

        /// <summary>
        /// A reference to the related Session resource.
        /// </summary>
        public SessionReference sessionReference { get; set; }

        /// <summary>
        /// The local code assigned by the LEA that identifies the organization of subject matter and related learning experiences provided for the instruction of students.
        /// </summary>
        public string localCourseCode { get; set; }

        /// <summary>
        /// The descriptive name given to a course of study offered in the school, if different from the CourseTitle.
        /// </summary>
        public string localCourseTitle { get; set; }

        /// <summary>
        /// The planned total number of clock minutes of instruction for this course offering. Generally, this should be at least as many minutes as is required for completion by the related state- or district-defined course.
        /// </summary>
        public int? instructionalTimePlanned { get; set; }

        /// <summary>
        /// An unordered collection of courseOfferingCurriculumUseds.  The type of curriculum used in an early learning classroom or group.
        /// </summary>
        public List<CourseOfferingCurriculumUsed> curriculumUseds { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

