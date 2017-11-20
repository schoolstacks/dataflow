using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentProgramAssociationReference 
    {
        /// <summary>
        /// A unique alpha-numeric code assigned to a student.
        /// </summary>
        public string studentUniqueId { get; set; }

        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string programType { get; set; }

        /// <summary>
        /// The formal name of the program of instruction, training, services or benefits available through federal, state, or local agencies.
        /// </summary>
        public string programName { get; set; }

        /// <summary>
        /// The education organization where the student is participating in or receiving the program services.
        /// </summary>
        public int? programEducationOrganizationId { get; set; }

        /// <summary>
        /// The month, day, and year on which the Student first received services.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related studentProgramAssociation resource.
        /// </summary>
        public Link link { get; set; }

        }
}

