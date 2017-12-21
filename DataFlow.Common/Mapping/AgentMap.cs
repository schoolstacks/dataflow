using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class AgentMap : EntityTypeConfiguration<Agent>
    {
        public AgentMap()
        {
            this.ToTable("Agent");
            this.HasKey(e => e.Id);

            this.Property(e => e.AgentTypeCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
