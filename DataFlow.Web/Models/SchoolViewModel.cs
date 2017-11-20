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
    }
}