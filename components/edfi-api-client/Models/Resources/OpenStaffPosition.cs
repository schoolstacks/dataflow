using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class OpenStaffPosition 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related EducationOrganization resource.
        /// </summary>
        public EducationOrganizationReference educationOrganizationReference { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string employmentStatusDescriptor { get; set; }

        /// <summary>
        /// The position''s title or rank (e.g., Counselor, teacher, etc)
        /// </summary>
        public string staffClassificationDescriptor { get; set; }

        /// <summary>
        /// The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.
        /// </summary>
        public string requisitionNumber { get; set; }

        /// <summary>
        /// Date the OpenStaffPosition was posted.
        /// </summary>
        public DateTime? datePosted { get; set; }

        /// <summary>
        /// The descriptive name of an individual's position.
        /// </summary>
        public string positionTitle { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string programAssignmentDescriptor { get; set; }

        /// <summary>
        /// The date the posting was removed or filled.
        /// </summary>
        public DateTime? datePostingRemoved { get; set; }

        /// <summary>
        /// Indication of whether the position was filled or retired without filling.
        /// </summary>
        public string postingResultType { get; set; }

        /// <summary>
        /// An unordered collection of openStaffPositionAcademicSubjects.  The teaching field required for the position: for example: English/Language Arts, Reading, Mathematics, Science, Social Sciences, etc.
        /// </summary>
        public List<OpenStaffPositionAcademicSubject> academicSubjects { get; set; }

        /// <summary>
        /// An unordered collection of openStaffPositionInstructionalGradeLevels.  The set of grade levels for which the position's assignment is responsible.
        /// </summary>
        public List<OpenStaffPositionInstructionalGradeLevel> instructionalGradeLevels { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

