using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DataFlow.EdFi.Models.Resources 
{
    public class AssessmentIdentificationCode 
    {
        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        [JsonProperty(PropertyName = "assessmentIdentificationSystemDescriptor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an Identification System.")]
        [Display(Name = "Identification System")]
        public string AssessmentIdentificationSystemDescriptor { get; set; }

        /// <summary>
        /// The organization code or name assigning the assessment identification code.
        /// </summary>
        [JsonProperty(PropertyName = "assigningOrganizationIdentificationCode")]
        public string AssigningOrganizationIdentificationCode { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.
        /// </summary>
        [JsonProperty(PropertyName = "identificationCode")]
        public string IdentificationCode { get; set; }

        }
}

