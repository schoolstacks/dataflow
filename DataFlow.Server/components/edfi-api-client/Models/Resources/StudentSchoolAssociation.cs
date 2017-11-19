using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StudentSchoolAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related GraduationPlan resource.
        /// </summary>
        public GraduationPlanReference graduationPlanReference { get; set; }

        /// <summary>
        /// A reference to the related School resource.
        /// </summary>
        public SchoolReference schoolReference { get; set; }

        /// <summary>
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference classOfSchoolYearTypeReference { get; set; }

        /// <summary>
        /// A reference to the related SchoolYearType resource.
        /// </summary>
        public SchoolYearTypeReference schoolYearTypeReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// The month, day, and year on which an individual enters and begins to receive instructional services in a school.
        /// </summary>
        public DateTime? entryDate { get; set; }

        /// <summary>
        /// The grade level or primary instructional level at which a student enters and receives services in a school or an educational institution during a given academic session.
        /// </summary>
        public string entryGradeLevelDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string entryGradeLevelReasonType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string entryTypeDescriptor { get; set; }

        /// <summary>
        /// An indicator of whether the student is enrolling to repeat a grade level, either by failure or an agreement to hold the student back.
        /// </summary>
        public bool? repeatGradeIndicator { get; set; }

        /// <summary>
        /// An indication of whether students transferred in or out of the school did so during the school year under the provisions for public school choice in accordance with Title I, Part A, Section 1116.
        /// </summary>
        public bool? schoolChoiceTransfer { get; set; }

        /// <summary>
        /// The month, day, and year of the first day after the date of an individual's last attendance at a school (if known), the day on which an individual graduated, or the date on which it becomes known officially that an individual left school.
        /// </summary>
        public DateTime? exitWithdrawDate { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string exitWithdrawTypeDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string residencyStatusDescriptor { get; set; }

        /// <summary>
        /// Indicates if a given enrollment record should be considered the primary record for a student. If omitted, the default is true.
        /// </summary>
        public bool? primarySchool { get; set; }

        /// <summary>
        /// An individual who is a paid employee or works in his or her own business, profession, or farm and at the same time is enrolled in secondary, postsecondary, or adult education.
        /// </summary>
        public bool? employedWhileEnrolled { get; set; }

        /// <summary>
        /// An unordered collection of studentSchoolAssociationEducationPlans.  Indicates the type of Education Plan(s) the student is following, if appropriate; for example: Special Education IEP or Vocational/CTE, etc.
        /// </summary>
        public List<StudentSchoolAssociationEducationPlan> educationPlans { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

