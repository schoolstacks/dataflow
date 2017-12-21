using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class ConfigurationMap : EntityTypeConfiguration<Configuration>
    {
        public ConfigurationMap()
        {
            this.ToTable("Configuration");
            this.HasKey(x => x.Key);

            this.Property(e => e.Key)
                .HasMaxLength(255);
        }
    }
}