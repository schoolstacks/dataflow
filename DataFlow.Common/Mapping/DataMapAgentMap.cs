using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class DataMapAgentMap : EntityTypeConfiguration<DataMapAgent>
    {
        public DataMapAgentMap()
        {
            this.ToTable("datamap_agent", "dataflow");
            this.HasKey(x => x.Id);

            this.Property(e => e.Id).HasColumnName("ID");

            this.Property(e => e.AgentId).HasColumnName("AgentID");

            this.Property(e => e.DataMapId).HasColumnName("DataMapID");

            this.HasRequired(d => d.Agent)
                .WithMany(p => p.DataMapAgents)
                .HasForeignKey(d => d.AgentId);

            this.HasRequired(d => d.DataMap)
                .WithMany(p => p.DataMapAgents)
                .HasForeignKey(d => d.DataMapId);
        }
    }
}