using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StaffEducationOrganizationAssignmentAssociation 
    {
        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A reference to the related StaffEducationOrganizationEmploymentAssociation resource.
        /// </summary>
        public StaffEducationOrganizationEmploymentAssociationReference employmentStaffEducationOrganizationEmploymentAssociationReference { get; set; }

        /// <summary>
        /// A reference to the related EducationOrganization resource.
        /// </summary>
        public EducationOrganizationReference educationOrganizationReference { get; set; }

        /// <summary>
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// The titles of employment, official status, or rank of education staff.
        /// </summary>
        public string staffClassificationDescriptor { get; set; }

        /// <summary>
        /// Month, day, and year of the start or effective date of a staff member's employment, contract, or relationship with the LEA.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The descriptive name of an individual's position.
        /// </summary>
        public string positionTitle { get; set; }

        /// <summary>
        /// Month, day, and year of the end or termination date of a staff member's employment, contract, or relationship with the LEA.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Describes whether the assignment is this the staff member's primary assignment, secondary assignment, etc.
        /// </summary>
        public int? orderOfAssignment { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

