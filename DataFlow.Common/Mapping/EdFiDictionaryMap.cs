using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class EdFiDictionaryMap : EntityTypeConfiguration<EdfiDictionary>
    {
        public EdFiDictionaryMap()
        {
            this.ToTable("EdFiDictionary", "dbo");
            this.HasKey(x => x.Id);

            /* this.Property(e => e.Id).HasColumnName("ID"); */

            this.Property(e => e.DisplayValue)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            this.Property(e => e.GroupSet)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            this.Property(e => e.OriginalValue)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}