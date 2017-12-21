using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class LogIngestionMap : EntityTypeConfiguration<LogIngestion>
    {
        public LogIngestionMap()
        {
            this.ToTable("LogIngestion");
            this.HasKey(x => x.Id);

            this.Property(e => e.Date).HasColumnType("datetime");

            this.Property(e => e.Level)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            this.Property(e => e.Message).IsUnicode(false);

            this.Property(e => e.Operation)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            this.Property(e => e.Process)
                .IsRequired()
                .IsUnicode(false);

            this.Property(e => e.Result)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            this.HasRequired(d => d.Agent)
                .WithMany(p => p.LogIngestions)
                .HasForeignKey(d => d.AgentId);
        }
    }
}