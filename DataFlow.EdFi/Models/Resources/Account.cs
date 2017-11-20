using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class Account 
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
        /// The alpha-numeric string that identifies the account.
        /// </summary>
        public string number { get; set; }

        /// <summary>
        /// The financial accounting year.
        /// </summary>
        public int? fiscalYear { get; set; }

        /// <summary>
        /// An unordered collection of accountCodes.  The set of account codes defined for the education accounting system organized by account code type (e.g., fund, function, object) that map to the account.
        /// </summary>
        public List<AccountCode> codes { get; set; }

        /// <summary>
        /// A unique system-generated value that identifies the version of the resource.
        /// </summary>
        public string _etag { get; set; }

        }
}

