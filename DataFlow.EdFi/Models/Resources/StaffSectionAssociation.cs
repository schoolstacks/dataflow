using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StaffSectionAssociation 
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
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string classroomPositionDescriptor { get; set; }

        /// <summary>
        /// Month, day, and year of a teacher's assignment to the Section. If blank, defaults to the first day of the first grading period for the Section.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// Month, day, and year of the last day of a staff member's assignment to the Section.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for this section being taught.
        /// </summary>
        public bool? highlyQualifiedTeacher { get; set; }

        /// <summary>
        /// Indicates that the entire section is excluded from calculation of value-added or growth attribution calculations used for a particular teacher evaluation.
        /// </summary>
        public bool? teacherStudentDataLinkExclusion { get; set; }

        /// <summary>
        /// Indicates the percentage of the total scheduled course time, academic standards, and/or learning activities delivered in this section by this staff member. A teacher of record designation may be based solely or partially on this contribution percentage.
        /// </summary>
        public double? percentageContribution { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

