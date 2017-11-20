namespace DataFlow.EdFi.Models.Resources 
{
    public class StaffReference 
    {
        /// <summary>
        /// A unique alpha-numeric code assigned to a staff.
        /// </summary>
        public string staffUniqueId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related staff resource.
        /// </summary>
        public Link link { get; set; }

        }
}

