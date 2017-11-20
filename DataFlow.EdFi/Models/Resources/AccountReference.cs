namespace DataFlow.EdFi.Models.Resources 
{
    public class AccountReference 
    {
        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// The alpha-numeric string that identifies the account.
        /// </summary>
        public string number { get; set; }

        /// <summary>
        /// The financial accounting year.
        /// </summary>
        public int? fiscalYear { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related account resource.
        /// </summary>
        public Link link { get; set; }

        }
}

