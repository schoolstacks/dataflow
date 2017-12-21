using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class LookupMap : EntityTypeConfiguration<Lookup>
    {
        public LookupMap()
        {
            this.ToTable("Lookup");
            this.HasKey(x => x.Id);

            this.Property(e => e.Id).HasColumnName("ID");

            this.Property(e => e.GroupSet)
                .IsRequired()
                .HasMaxLength(1024)
                .IsUnicode(false);

            this.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(1024)
                .IsUnicode(false);

            this.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(1024)
                .IsUnicode(false);
        }
    }
}