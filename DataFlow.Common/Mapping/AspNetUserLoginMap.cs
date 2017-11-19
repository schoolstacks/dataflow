using DataFlow.Models;
using System.Data.Entity.ModelConfiguration;

namespace DataFlow.Common.Mapping
{
    public class AspNetUserLoginMap : EntityTypeConfiguration<AspNetUserLogin>
    {
        public AspNetUserLoginMap()
        {
            this.ToTable("AspNetUserLogins", "dbo");
            this.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

            this.Property(e => e.LoginProvider)
                .HasMaxLength(128);

            this.Property(e => e.ProviderKey)
                .HasMaxLength(128);

            this.Property(e => e.UserId)
                .HasMaxLength(128);

            this.HasIndex(e => e.UserId)
                .HasName("IX_UserId");

            this.HasRequired(d => d.User)
                .WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId);
        }
    }
}
