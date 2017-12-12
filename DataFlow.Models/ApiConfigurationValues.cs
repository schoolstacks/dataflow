using System.ComponentModel.DataAnnotations;

namespace DataFlow.Models
{
    public class ApiConfigurationValues
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the API URL.")]
        [Display(Name="API Server URL")]
        public string API_SERVER_URL { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the API Server Key.")]
        [Display(Name = "API Server Key")]
        public string API_SERVER_KEY { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the API Server Secret.")]
        [Display(Name = "API Server Secret")]
        public string API_SERVER_SECRET { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select the default term month.")]
        [Display(Name = "Term Month")]
        public string DEFAULTS_TERM_MONTH { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select the default term year.")]
        [Display(Name = "Term Year")]
        public string DEFAULTS_TERM_YEAR { get; set; }

        [Display(Name = "Company Name")]
        public string INSTANCE_COMPANY_NAME { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Please enter a valid URL that points to an image file.")]
        [Display(Name = "Company Logo")]
        public string INSTANCE_COMPANY_LOGO { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Please enter a valid URL.")]
        [Display(Name = "Company URL")]
        public string INSTANCE_COMPANY_URL { get; set; }

        [Display(Name = "Education Use Text")]
        public string INSTANCE_EDU_USE_TEXT { get; set; }

        [Display(Name = "Allow User Registrations")]
        public bool INSTANCE_ALLOW_USER_REGISTRATION { get; set; }
    }
}
