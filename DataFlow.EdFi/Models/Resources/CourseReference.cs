namespace DataFlow.EdFi.Models.Resources 
{
    public class CourseReference 
    {
        /// <summary>
        /// The Education Organization that defines the curriculum and courses offered - often the LEA or school.
        /// </summary>
        public int? educationOrganizationId { get; set; }

        /// <summary>
        /// TThe actual code that identifies the organization of subject matter and related learning experiences provided for the instruction of students.
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related course resource.
        /// </summary>
        public Link link { get; set; }

        }
}

