using System.Collections.Generic;

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

            public List<DataFlow.EdFi.Models.EnrollmentComposite.Student> Students { get; set; }
            public List<DataFlow.EdFi.Models.EnrollmentComposite.Staff> Staves { get; set; }
            public List<DataFlow.EdFi.Models.EnrollmentComposite.Section> Sections { get; set; }
            public List<DataFlow.EdFi.Models.AssessmentComposite.Assessment> Assessments { get; set; }
        }
    }
}