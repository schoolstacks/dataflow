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
        public IDbSet<LogApplication> LogApplications { get; set; }
        public IDbSet<LogIngestion> LogIngestions { get; set; }
        public IDbSet<Lookup> Lookups { get; set; }
        public IDbSet<ProcessedData> ProcessedDatas { get; set; }
        public IDbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AgentMap());
            modelBuilder.Configurations.Add(new AgentScheduleMap());
            modelBuilder.Configurations.Add(new BootstrapDataMap());
            modelBuilder.Configurations.Add(new ConfigurationMap());
            modelBuilder.Configurations.Add(new DataMapAgentMap());
            modelBuilder.Configurations.Add(new DataMapMap());
            modelBuilder.Configurations.Add(new EdFiDictionaryMap());
            modelBuilder.Configurations.Add(new EntityMap());
            modelBuilder.Configurations.Add(new FileMap());
            modelBuilder.Configurations.Add(new FileStatusMap());
            modelBuilder.Configurations.Add(new LogApplicationMap());
            modelBuilder.Configurations.Add(new LogIngestionMap());
            modelBuilder.Configurations.Add(new LookupMap());
            modelBuilder.Configurations.Add(new MigrationHistoryMap());
            modelBuilder.Configurations.Add(new ProcessedDataMap());
            modelBuilder.Configurations.Add(new StatisticMap());

            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserRoleMap());
            modelBuilder.Configurations.Add(new AspNetUsersMap());
        }
    }
}
