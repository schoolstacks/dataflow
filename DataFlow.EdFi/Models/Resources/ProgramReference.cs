namespace DataFlow.EdFi.Models.Resources 
{
    public class ProgramReference 
    {
        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// Key for Program
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The formal name of the program of instruction, training, services or benefits available through federal, state, or local agencies.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related program resource.
        /// </summary>
        public Link link { get; set; }

        }
}

