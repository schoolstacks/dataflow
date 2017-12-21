using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class DataMapMap : EntityTypeConfiguration<DataMap>
    {
        public DataMapMap()
        {
            this.ToTable("DataMap", "dbo");
            this.HasKey(x => x.Id);

            /* this.Property(e => e.Id)
                .HasColumnName("ID"); */

            this.Property(e => e.CreateDate)
                .HasColumnType("datetime");

            /* this.Property(e => e.EntityId)
                .HasColumnName("EntityID"); */

            this.Property(e => e.Map)
                .IsUnicode(false);

            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            this.Property(e => e.UpdateDate).HasColumnType("datetime");

            this.HasRequired(d => d.Entity)
                .WithMany(p => p.DataMaps)
                .HasForeignKey(d => d.EntityId);
        }
    }
}
