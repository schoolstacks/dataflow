using System.Data.Entity.Migrations;
using DataFlow.Models;

namespace DataFlow.Common.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DataFlowDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataFlow.Common.DAL.DataFlowDbContext context)
        {
            context.FileStatuses.AddOrUpdate(
                            new FileStatus() { Value = "ERROR_LOADING" },
                            new FileStatus() { Value = "ERROR_TRANSFORM" },
                            new FileStatus() { Value = "ERROR_UPLOADED" },
                            new FileStatus() { Value = "LOADED" },
                            new FileStatus() { Value = "LOADING" },
                            new FileStatus() { Value = "TRANSFORMING" },
                            new FileStatus() { Value = "UPLOADED" },
                            new FileStatus() { Value = "RETRY" });

            context.EdfiDictionary.AddOrUpdate(
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
        }
    }
}
