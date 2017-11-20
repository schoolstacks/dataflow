using System;
using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StudentMigrantEducationProgramAssociation 
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
        /// A reference to the related Program resource.
        /// </summary>
        public ProgramReference programReference { get; set; }

        /// <summary>
        /// A reference to the related Student resource.
        /// </summary>
        public StudentReference studentReference { get; set; }

        /// <summary>
        /// The month, day, and year on which the Student first received services.
        /// </summary>
        public DateTime? beginDate { get; set; }

        /// <summary>
        /// The month, day, and year on which the Student exited the Program or stopped receiving services.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string reasonExitedDescriptor { get; set; }

        /// <summary>
        /// Indicates whether the Student received services during the summer session or between sessions.
        /// </summary>
        public bool? servedOutsideOfRegularSession { get; set; }

        /// <summary>
        /// Report migratory children who are classified as having "priority for services" because they are failing, or most at risk of failing to meet the State's challenging State academic content standards and challenging State student academic achievement standards, and their education has been interrupted during the regular school year.
        /// </summary>
        public bool? priorityForServices { get; set; }

        /// <summary>
        /// Date the last qualifying move occurred; used to compute MEP status.
        /// </summary>
        public DateTime? lastQualifyingMove { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string continuationOfServicesReasonDescriptor { get; set; }

        /// <summary>
        /// The month, day, and year on which the Student first entered the U.S.
        /// </summary>
        public DateTime? usInitialEntry { get; set; }

        /// <summary>
        /// The month, day, and year of the Student's most recent entry into the U.S.
        /// </summary>
        public DateTime? usMostRecentEntry { get; set; }

        /// <summary>
        /// The month, day, and year on which the Student first entered a U.S. school.
        /// </summary>
        public DateTime? usInitialSchoolEntry { get; set; }

        /// <summary>
        /// An unordered collection of studentProgramAssociationServices.  Indicates the services being provided to the student by the program.
        /// </summary>
        public List<StudentProgramAssociationService> services { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

