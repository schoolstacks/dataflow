using System.Data.Entity.ModelConfiguration;

namespace DataFlow.Common.Mapping
{
    public class NLogMap : EntityTypeConfiguration<Models.NLog>
    {
        public NLogMap()
        {
            this.ToTable("NLog", "dbo");
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .HasColumnName("ID");

            this.Property(x => x.MachineName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .IsRequired();

            this.Property(x => x.SiteName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .IsRequired();

            this.Property(x => x.Logged)
                .IsRequired();

            this.Property(x => x.Level)
                .HasMaxLength(5)
                .IsUnicode(true)
                .IsRequired();

            this.Property(x => x.UserName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .IsOptional();

            this.Property(x => x.Message)
                .HasMaxLength(null)
                .IsUnicode(true)
                .IsRequired();

            this.Property(x => x.Logger)
                .HasMaxLength(300)
                .IsUnicode(true)
                .IsOptional();

            this.Property(x => x.Properties)
                .HasMaxLength(null)
                .IsUnicode(true)
                .IsOptional();

            this.Property(x => x.ServerName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .IsOptional();

            this.Property(x => x.Port)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsOptional();

            this.Property(x => x.Url)
                .HasMaxLength(2000)
                .IsUnicode(true)
                .IsOptional();

            this.Property(x => x.Https)
                .IsOptional();

            this.Property(x => x.ServerAddress)
                .HasMaxLength(100)
                .IsUnicode(true);

            this.Property(x => x.RemoteAddress)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsOptional();

            this.Property(x => x.Callsite)
                .HasMaxLength(300)
                .IsUnicode(true)
                .IsOptional();

            this.Property(x => x.Exception)
                .HasMaxLength(null)
                .IsUnicode(true)
                .IsOptional();
        }
    }
}