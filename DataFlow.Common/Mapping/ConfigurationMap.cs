using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class ConfigurationMap : EntityTypeConfiguration<Configuration>
    {
        public ConfigurationMap()
        {
            this.ToTable("Configuration", "dbo");
            this.HasKey(x => x.Key);

            this.Property(e => e.Key)
                .HasMaxLength(255);

            this.Property(e => e.Category)
                .HasMaxLength(255);

            this.Property(e => e.Type)
                .HasMaxLength(255);
        }
    }
}