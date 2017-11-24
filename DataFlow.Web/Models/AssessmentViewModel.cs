using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace DataFlow.Web.Models
{
    public class AssessmentViewModel
    {
        public class AddOrEdit
        {
            public DataFlow.EdFi.Models.Resources.Assessment Assessment { get; set; }
            public DataFlow.EdFi.Models.Resources.AssessmentIdentificationCode IdentificationCode { get; set; }
            public DataFlow.EdFi.Models.Resources.ObjectiveAssessment ObjectiveAssessment { get; set; }

            [Display(Name = "Grade Levels")]
            public List<CheckBox> GradeLevels { get; set; }
        }
    }
}