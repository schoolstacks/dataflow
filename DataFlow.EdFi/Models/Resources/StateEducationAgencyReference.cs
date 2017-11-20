namespace DataFlow.EdFi.Models.Resources 
{
    public class StateEducationAgencyReference 
    {
        /// <summary>
        /// The identifier assigned to a state education agency by the StateEducationAgency (SEA).
        /// </summary>
        public int? stateEducationAgencyId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related stateEducationAgency resource.
        /// </summary>
        public Link link { get; set; }

        }
}

