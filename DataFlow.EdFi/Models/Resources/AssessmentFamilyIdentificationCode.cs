namespace DataFlow.EdFi.Models.Resources 
{
    public class AssessmentFamilyIdentificationCode 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string assessmentIdentificationSystemDescriptor { get; set; }

        /// <summary>
        /// The organization code or name assigning the assessment identification code.
        /// </summary>
        public string assigningOrganizationIdentificationCode { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.
        /// </summary>
        public string identificationCode { get; set; }

        }
}

