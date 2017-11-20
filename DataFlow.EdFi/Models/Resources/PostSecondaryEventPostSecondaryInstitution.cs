using System.Collections.Generic;

namespace DataFlow.EdFi.Models.Resources 
{
    public class PostSecondaryEventPostSecondaryInstitution 
    {
        /// <summary>
        /// The full, legally accepted name of the institution.
        /// </summary>
        public string nameOfInstitution { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to the postsecondary organization.
        /// </summary>
        public string postSecondaryInstitutionId { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string postSecondaryInstitutionLevelType { get; set; }

        /// <summary>
        /// Key for AdministrationFundingControl
        /// </summary>
        public string administrativeFundingControlDescriptor { get; set; }

        /// <summary>
        /// An unordered collection of postSecondaryEventPostSecondaryInstitutionIdentificationCodes.  A unique number or alphanumeric code assigned to an education organization by a school, school system, state or other agency or entity.
        /// </summary>
        public List<PostSecondaryEventPostSecondaryInstitutionIdentificationCode> identificationCodes { get; set; }

        /// <summary>
        /// An unordered collection of postSecondaryEventPostSecondaryInstitutionMediumOfInstructions.  The categories in which an institution serves the students.
        /// </summary>
        public List<PostSecondaryEventPostSecondaryInstitutionMediumOfInstruction> mediumOfInstructions { get; set; }

        }
}

