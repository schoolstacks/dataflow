using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DataFlow.Web.Models
{
    public class AssessmentViewModel
    {
        public class AddOrEdit
        {
            public DataFlow.EdFi.Models.AssessmentComposite.Assessment Assessment { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Please select the grade level(s) for this assessment.")]
            [Display(Name = "Grade Levels")]
            public List<CheckBox> GradeLevels { get; set; }
        }
    }
}