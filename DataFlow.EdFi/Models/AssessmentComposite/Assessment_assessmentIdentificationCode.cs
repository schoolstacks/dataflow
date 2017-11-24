using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DataFlow.EdFi.Models.AssessmentComposite 
{
    public class Assessment_assessmentIdentificationCode 
    {
        /// <summary>
        /// The organization code or name assigning the assessment identification code.
        /// </summary>
        [JsonProperty(PropertyName = "assigningOrganizationIdentificationCode")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an Identification Code.")]
        [Display(Name = "Identification Code")]
        public string AssigningOrganizationIdentificationCode { get; set; }

        /// <summary>
        /// A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, a state, or other agency or entity.
        /// </summary>
        public string identificationCode { get; set; }

        }
}

