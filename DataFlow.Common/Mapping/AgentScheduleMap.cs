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

            /* this.Property(e => e.Id)
                .HasColumnName("Id");

            this.Property(e => e.AgentId)
                .HasColumnName("AgentId"); */

            this.HasRequired(d => d.Agent)
                .WithMany(p => p.AgentSchedules)
                .HasForeignKey(d => d.AgentId);
        }
    }
}
