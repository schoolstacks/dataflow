using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class EntityMap : EntityTypeConfiguration<Entity>
    {
        public EntityMap()
        {
            this.ToTable("entity", "dataflow");
            this.HasKey(x => x.Id);

            this.Property(e => e.Id).HasColumnName("ID");

            this.Property(e => e.CreateDate).HasColumnType("date");

            this.Property(e => e.Family).IsUnicode(false);

            this.Property(e => e.Metadata).IsUnicode(false);

            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            this.Property(e => e.Namespace).IsUnicode(false);

            this.Property(e => e.UpdateDate).HasColumnType("date");

            this.Property(e => e.Url)
                .HasColumnName("URL")
                .IsUnicode(false);
        }
    }
}