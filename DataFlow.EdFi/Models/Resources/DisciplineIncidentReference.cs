namespace DataFlow.EdFi.Models.Resources 
{
    public class DisciplineIncidentReference 
    {
        /// <summary>
        /// A locally assigned unique identifier (within the school or school district) to identify each specific incident or occurrence. The same identifier should be used to document the entire incident even if it included multiple offenses and multiple offenders.
        /// </summary>
        public string incidentIdentifier { get; set; }

        /// <summary>
        /// School Identity Column
        /// </summary>
        public int? schoolId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related disciplineIncident resource.
        /// </summary>
        public Link link { get; set; }

        }
}

