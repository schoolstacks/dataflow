using System.ComponentModel.DataAnnotations;

namespace DataFlow.EdFi.Models.Resources 
{
    public class LocalEducationAgencyReference 
    {
        /// <summary>
        /// The identifier assigned to a local education agency by the State Education Agency (SEA).
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select a district.")]
        public int? localEducationAgencyId { get; set; }

        /// <summary>
        /// Represents a hyperlink to the related localEducationAgency resource.
        /// </summary>
        public Link link { get; set; }

        }
}

