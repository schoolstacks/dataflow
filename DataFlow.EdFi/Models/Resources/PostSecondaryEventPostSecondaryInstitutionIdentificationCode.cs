namespace DataFlow.EdFi.Models.Resources 
{
    public class PostSecondaryEventPostSecondaryInstitutionIdentificationCode 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string educationOrganizationIdentificationSystemDescriptor { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code that is assigned to an education organization by a school, school system, a state, or other agency or entity.
        /// </summary>
        public string identificationCode { get; set; }

        }
}

