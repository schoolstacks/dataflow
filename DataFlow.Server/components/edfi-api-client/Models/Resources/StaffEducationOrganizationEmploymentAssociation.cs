using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Models.Resources 
{
    public class StaffEducationOrganizationEmploymentAssociation 
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
        /// A reference to the related Staff resource.
        /// </summary>
        public StaffReference staffReference { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string employmentStatusDescriptor { get; set; }

        /// <summary>
        /// The month, day, and year on which an individual was hired for a position.
        /// </summary>
        public DateTime? hireDate { get; set; }

        /// <summary>
        /// The month, day, and year on which a contract between an individual and a governing authority ends or is terminated under the provisions of the contract (or the date on which the agreement is made invalid).
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Type of employment separation; for example:  Voluntary separation  Involuntary separation  Mutual agreement  Other
        /// </summary>
        public string separationType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string separationReasonDescriptor { get; set; }

        /// <summary>
        /// The department or suborganization the employee/contractor is associated with in the Education Organization.
        /// </summary>
        public string department { get; set; }

        /// <summary>
        /// The ratio between the hours of work expected in a position and the hours of work normally expected in a full-time position in the same setting.
        /// </summary>
        public double? fullTimeEquivalency { get; set; }

        /// <summary>
        /// Date at which the staff member was made an official offer for this employment.
        /// </summary>
        public DateTime? offerDate { get; set; }

        /// <summary>
        /// Hourly wage associated with the employment position being reported.
        /// </summary>
        public double? hourlyWage { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

