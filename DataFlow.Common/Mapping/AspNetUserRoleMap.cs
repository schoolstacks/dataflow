using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class AspNetUserRoleMap : EntityTypeConfiguration<AspNetUserRole>
    {
        public AspNetUserRoleMap()
        {
            this.ToTable("AspNetUserRoles");
            this.HasKey(x => new { x.UserId, x.RoleId });

            this.Property(e => e.UserId)
                .HasMaxLength(128);

            this.Property(e => e.RoleId)
                .HasMaxLength(128);

            this.HasIndex(e => e.RoleId)
                .HasName("IX_RoleId");

            this.HasIndex(e => e.UserId)
                .HasName("IX_UserId");

            this.HasRequired(d => d.Role)
                .WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.RoleId);

            this.HasRequired(d => d.User)
                .WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.UserId);
        }
    }
}