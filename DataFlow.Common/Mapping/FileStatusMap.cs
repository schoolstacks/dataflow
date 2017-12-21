using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class FileStatusMap : EntityTypeConfiguration<FileStatus>
    {
        public FileStatusMap()
        {
            this.ToTable("FileStatus");
            this.HasKey(x => x.Value);

            this.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}