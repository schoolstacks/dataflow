using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StaffEducationOrganizationEmploymentAssociationReference 
    {
        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// A unique alpha-numeric code assigned to a staff.
        /// </summary>
        public string staffUniqueId { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string employmentStatusDescriptor { get; set; }

        /// <summary>
        /// The month, day, and year on which an individual was hired for a position.
        /// </summary>
        public DateTime? hireDate { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related staffEducationOrganizationEmploymentAssociation resource.
        /// </summary>
        public Link link { get; set; }

        }
}

