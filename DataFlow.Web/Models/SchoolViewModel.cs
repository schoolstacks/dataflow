using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace DataFlow.Web.Models
{
    public class SchoolViewModel
    {
        public class Grid
        {
            public string Id { get; set; }
            public string LocalEducationAgencyId { get; set; }
            public string Name { get; set; }
            public string Abbreviation { get; set; }
            public int StaffCount { get; set; }
            public int StudentCount { get; set; }
            public string LastIngestionDate { get; set; }
        }

        public class Detail
        {
            public string Id { get; set; }
            public string Name { get; set; }

            public List<EdFi.Models.EnrollmentComposite.Student> Students { get; set; }
            public List<EdFi.Models.EnrollmentComposite.Staff> Staves { get; set; }
            public List<EdFi.Models.EnrollmentComposite.Section> Sections { get; set; }
            public List<EdFi.Models.AssessmentComposite.Assessment> Assessments { get; set; }
        }

        public class AddOrUpdate
        {
            public EdFi.Models.Resources.School School { get; set; }
            public EdFi.Models.Resources.EducationOrganizationAddress MailingAddress { get; set; }
            [Display(Name = "Grade Levels")]
            public List<CheckBox> GradeLevels { get; set; }
        }
    }
}