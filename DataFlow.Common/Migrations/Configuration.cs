using System.Data.Entity.Migrations;
using DataFlow.Models;

namespace DataFlow.Common.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<DAL.DataFlowDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public void ForceSeed(DataFlow.Common.DAL.DataFlowDbContext context)
        {
            this.Seed(context);
        }

        protected override void Seed(DataFlow.Common.DAL.DataFlowDbContext context)
        {
            context.FileStatuses.AddOrUpdate(x => x.Value,
                new FileStatus() {Value = "ERROR_LOADING"},
                new FileStatus() {Value = "ERROR_TRANSFORM"},
                new FileStatus() {Value = "ERROR_UPLOADED"},
                new FileStatus() {Value = "LOADED"},
                new FileStatus() {Value = "LOADING"},
                new FileStatus() {Value = "TRANSFORMING"},
                new FileStatus() {Value = "UPLOADED"},
                new FileStatus() {Value = "RETRY"},
                new FileStatus() {Value = "DELETED"}
            );

            context.EdfiDictionary.AddOrUpdate(x => new { x.GroupSet, x.OriginalValue, x.DisplayValue, x.DisplayOrder },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Kindergarten", DisplayValue = "Kindergarten", DisplayOrder = 1 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "First grade", DisplayValue = "1st Grade", DisplayOrder = 2 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Second grade", DisplayValue = "2nd Grade", DisplayOrder = 3 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Third Grade", DisplayValue = "3rd Grade", DisplayOrder = 4 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Fourth grade", DisplayValue = "4th Grade", DisplayOrder = 5 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Fifth grade", DisplayValue = "5th Grade", DisplayOrder = 6 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Sixth grade", DisplayValue = "6th Grade", DisplayOrder = 7 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Seventh grade", DisplayValue = "7th Grade", DisplayOrder = 8 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Eigth grade", DisplayValue = "8th Grade", DisplayOrder = 9 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Ninth grade", DisplayValue = "9th Grade", DisplayOrder = 10 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Tenth grade", DisplayValue = "10th Grade", DisplayOrder = 11 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Eleventh grade", DisplayValue = "11th Grade", DisplayOrder = 12 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Twelfth grade", DisplayValue = "12th Grade", DisplayOrder = 13 },
                new EdfiDictionary() { GroupSet = "levelDescriptors", OriginalValue = "Ungraded", DisplayValue = "Ungraded", DisplayOrder = 100 }
            );

            context.Entities.AddOrUpdate(x => new {x.Name, x.Url},
                new Entity() {Name = "students", Url = "/metadata/resources/api-docs/students"},
                new Entity() {Name = "studentAssessments", Url = "/metadata/resources/api-docs/studentAssessments"},
                new Entity() {Name = "studentSchoolAssociations", Url = "/metadata/resources/api-docs/studentSchoolAssociations"},
                new Entity() {Name = "studentSectionAssociations", Url = "/metadata/resources/api-docs/studentSectionAssociations"},
                new Entity() {Name = "staffs", Url = "/metadata/resources/api-docs/staffs"},
                new Entity() {Name = "assessments", Url = "/metadata/resources/api-docs/assessments"},
                new Entity() {Name = "staffSchoolAssociations", Url = "/metadata/resources/api-docs/staffSchoolAssociations"},
                new Entity() {Name = "staffSectionAssociations", Url = "/metadata/resources/api-docs/staffSectionAssociations"},
                new Entity() {Name = "schools", Url = "/metadata/resources/api-docs/schools"},
                new Entity() {Name = "localEducationAgencies", Url = "/metadata/resources/api-docs/localEducationAgencies"},
                new Entity() {Name = "sections", Url = "/metadata/resources/api-docs/sections"},
                new Entity() {Name = "assessmentItem", Url = "/metadata/resources/api-docs/assessmentItem"},
                new Entity() {Name = "objectiveAssessment", Url = "/metadata/resources/api-docs/objectiveAssessments"},
                new Entity() {Name = "performanceLevels", Url = "/metadata/descriptors/api-docs/performanceLevelDescriptors"}
            );

            context.SaveChanges();
        }
    }
}
