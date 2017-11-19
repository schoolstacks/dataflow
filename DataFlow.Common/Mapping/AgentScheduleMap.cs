using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class AgentScheduleMap : EntityTypeConfiguration<AgentSchedule>
    {
        public AgentScheduleMap()
        {
            this.ToTable("agent_schedule", "dataflow");
            this.HasKey(e => e.Id);

            this.Property(e => e.Id)
                .HasColumnName("ID");

            this.Property(e => e.AgentId)
                .HasColumnName("AgentID");
        }
    }
}
