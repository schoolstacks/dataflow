using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class LogApplicationMap : EntityTypeConfiguration<LogApplication>
    {
        public LogApplicationMap()
        {
            this.ToTable("LogApplication");
            this.HasKey(x => x.Id);

            this.Property(e => e.Id).HasColumnName("ID");

            this.Property(e => e.Date).HasColumnType("datetime");

            this.Property(e => e.Exception)
                .HasMaxLength(2000)
                .IsUnicode(false);

            this.Property(e => e.Level)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            this.Property(e => e.Logger)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            this.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(4000)
                .IsUnicode(false);

            this.Property(e => e.Thread)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}