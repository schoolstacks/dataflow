using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class DataMapAgentMap : EntityTypeConfiguration<DataMapAgent>
    {
        public DataMapAgentMap()
        {
            this.ToTable("DataMapAgent");
            this.HasKey(x => x.Id);

            this.HasRequired(d => d.Agent)
                .WithMany(p => p.DataMapAgents)
                .HasForeignKey(d => d.AgentId);

            this.HasRequired(d => d.DataMap)
                .WithMany(p => p.DataMapAgents)
                .HasForeignKey(d => d.DataMapId);
        }
    }
}