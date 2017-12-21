using System;
using System.Data.Entity;
using DataFlow.Common.Mapping;
using DataFlow.Models;

namespace DataFlow.Common.DAL
{
    public class DataFlowDbContext : DbContext, IDisposable
    {
        static DataFlowDbContext()
        {
            Database.SetInitializer<DataFlowDbContext>(null);
        }

        public DataFlowDbContext() : base("Name=defaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Agent> Agents { get; set; }
        public IDbSet<AgentSchedule> AgentSchedules { get; set; }
        public IDbSet<AspNetRole> AspNetRoles { get; set; }
        public IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public IDbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public IDbSet<AspNetUser> AspNetUsers { get; set; }
        public IDbSet<BootstrapData> BootstrapData { get; set; }
        public IDbSet<Configuration> Configurations { get; set; }
        public IDbSet<DataMap> DataMaps { get; set; }
        public IDbSet<DataMapAgent> DatamapAgents { get; set; }
        public IDbSet<EdfiDictionary> EdfiDictionary { get; set; }
        public IDbSet<Entity> Entities { get; set; }
        public IDbSet<File> Files { get; set; }
        public IDbSet<FileStatus> FileStatuses { get; set; }
        public IDbSet<LogIngestion> LogIngestions { get; set; }
        public IDbSet<Models.NLog> NLogs { get; set; }
        public IDbSet<Lookup> Lookups { get; set; }
        public IDbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserRoleMap());
            modelBuilder.Configurations.Add(new AspNetUsersMap());
        }
    }
}
