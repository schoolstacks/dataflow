using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class BootstrapDataMap : EntityTypeConfiguration<BootstrapData>
    {
        public BootstrapDataMap()
        {
            this.ToTable("BootstrapData");
            this.HasKey(e => e.Id);

            this.Property(e => e.CreateDate)
                .HasColumnType("datetime");

            this.Property(e => e.Data)
                .IsRequired()
                .IsUnicode(false);

            this.Property(e => e.ProcessedDate)
                .HasColumnType("datetime");

            this.Property(e => e.UpdateDate)
                .HasColumnType("datetime");

            this.HasRequired(d => d.Entity)
                .WithMany(p => p.BootstrapDatas)
                .HasForeignKey(d => d.EntityId);
        }
    }
}
