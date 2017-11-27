using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace DataFlow.Web.Models
{
    public class AssessmentViewModel
    {
        public class AddOrEdit
        {
            public EdFi.Models.Resources.Assessment Assessment { get; set; }
            public EdFi.Models.Resources.AssessmentIdentificationCode IdentificationCode { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter object assessment(s) separated by new lines.")]
            [Display(Name = "Objective Assessments")]
            public string ObjectiveAssessmentsText { get; set; }

            [Display(Name = "Grade Levels")]
            public List<CheckBox> GradeLevels { get; set; }
        }
    }
}