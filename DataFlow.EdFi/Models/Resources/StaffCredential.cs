using System;

namespace DataFlow.EdFi.Models.Resources 
{
    public class StaffCredential 
    {
        /// <summary>
        /// The field of certification for the certificate (e.g., Mathematics, Music)
        /// </summary>
        public string credentialFieldDescriptor { get; set; }

        /// <summary>
        /// An indication of the category of credential an individual holds.
        /// </summary>
        public string credentialType { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string levelDescriptor { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string teachingCredentialDescriptor { get; set; }

        /// <summary>
        /// The month, day, and year on which an active credential was issued to an individual.
        /// </summary>
        public DateTime? credentialIssuanceDate { get; set; }

        /// <summary>
        /// The month, day, and year on which an active credential held by an individual will expire.
        /// </summary>
        public DateTime? credentialExpirationDate { get; set; }

        /// <summary>
        /// An indication of the pre-determined criteria for granting the teaching credential that an individual holds.
        /// </summary>
        public string teachingCredentialBasisType { get; set; }

        /// <summary>
        /// Key for StateAbbreviationType
        /// </summary>
        public string stateOfIssueStateAbbreviationType { get; set; }

        }
}

