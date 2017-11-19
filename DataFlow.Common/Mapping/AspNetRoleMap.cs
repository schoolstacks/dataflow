using DataFlow.Models;
using System.Data.Entity.ModelConfiguration;

namespace DataFlow.Common.Mapping
{
    public class AspNetRoleMap : EntityTypeConfiguration<AspNetRole>
    {
        public AspNetRoleMap()
        {
            this.ToTable("AspNetRoles", "dbo");
            this.HasKey(e => e.Id);

            this.Property(e => e.Id)
                .HasMaxLength(128);

            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(256);

            this.HasIndex(e => e.Name)
                .HasName("RoleNameIndex")
                .IsUnique();
        }
    }
}
