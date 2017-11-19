using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class MigrationHistoryMap : EntityTypeConfiguration<MigrationHistory>
    {
        public MigrationHistoryMap()
        {
            this.ToTable("__MigrationHistory", "dataflow");
            this.HasKey(e => new { e.MigrationId, e.ContextKey });

            this.Property(e => e.MigrationId).HasMaxLength(150);

            this.Property(e => e.ContextKey).HasMaxLength(300);

            this.Property(e => e.Model).IsRequired();

            this.Property(e => e.ProductVersion)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}