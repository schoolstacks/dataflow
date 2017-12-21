using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class FileMap : EntityTypeConfiguration<File>
    {
        public FileMap()
        {
            this.ToTable("File");
            this.HasKey(x => x.Id);

            // this.Property(e => e.CreateDate).HasColumnType("datetime");

            this.Property(e => e.FileName)
                .IsRequired()
                .IsUnicode(false);

            this.Property(e => e.Message).IsUnicode(false);

            this.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            this.Property(e => e.UpdateDate).HasColumnType("datetime");

            this.HasRequired(d => d.Agent)
                .WithMany(p => p.Files)
                .HasForeignKey(d => d.AgentId);

            this.HasRequired(d => d.StatusNavigation)
                .WithMany(p => p.Files)
                .HasForeignKey(d => d.Status);
        }
    }
}