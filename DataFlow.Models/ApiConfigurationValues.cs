using System.ComponentModel.DataAnnotations;

namespace DataFlow.Models
{
    public class ApiConfigurationValues
    {
        [Display(Name="API Server URL")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the url for the API.")]
        public string API_SERVER_URL { get; set; }
        [Display(Name = "API Server Key")]
        public string API_SERVER_KEY { get; set; }
        [Display(Name = "API Server Secret")]
        public string API_SERVER_SECRET { get; set; }
        [Display(Name = "Term Month")]
        public string DEFAULTS_TERM_MONTH { get; set; }
        [Display(Name = "Term Year")]
        public string DEFAULTS_TERM_YEAR { get; set; }
        [Display(Name = "Company Name")]
        public string INSTANCE_COMPANY_NAME { get; set; }
        [Display(Name = "Company Logo")]
        public string INSTANCE_COMPANY_LOGO { get; set; }
        [Display(Name = "Company URL")]
        public string INSTANCE_COMPANY_URL { get; set; }
        [Display(Name = "Education Use Text")]
        public string INSTANCE_EDU_USE_TEXT { get; set; }
    }
}
