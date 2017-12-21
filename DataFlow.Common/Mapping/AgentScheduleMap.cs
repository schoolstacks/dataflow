using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class AgentScheduleMap : EntityTypeConfiguration<AgentSchedule>
    {
        public AgentScheduleMap()
        {
            this.ToTable("AgentSchedule");
            this.HasKey(e => e.Id);

            this.HasRequired(d => d.Agent)
                .WithMany(p => p.AgentSchedules)
                .HasForeignKey(d => d.AgentId);
        }
    }
}
