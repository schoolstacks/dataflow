namespace DataFlow.EdFi.Models.Resources 
{
    public class GraduationPlanReference 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        public string typeDescriptor { get; set; }

        /// <summary>
        /// EducationOrganization Identity Column
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// Key for School
        /// </summary>
        public int? graduationSchoolYear { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related graduationPlan resource.
        /// </summary>
        public Link link { get; set; }

        }
}

