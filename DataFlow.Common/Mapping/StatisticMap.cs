using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class StatisticMap : EntityTypeConfiguration<Statistic>
    {
        public StatisticMap()
        {
            this.ToTable("statistic", "dataflow");
            this.HasKey(x => x.Id);

            this.Property(e => e.Id).HasColumnName("ID");

            this.Property(e => e.EntityId).HasColumnName("EntityID");

            this.Property(e => e.EntityType)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            this.Property(e => e.Measure)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}