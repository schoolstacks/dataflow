using System.Data.Entity.ModelConfiguration;
using DataFlow.Models;

namespace DataFlow.Common.Mapping
{
    public class AspNetUsersMap : EntityTypeConfiguration<AspNetUser>
    {
        public AspNetUsersMap()
        {
            this.ToTable("AspNetUsers", "dbo");

            this.HasKey(a => a.Id);

            this.Property(e => e.Id)
                .HasMaxLength(128);

            this.Property(e => e.Email)
                .HasMaxLength(256);

            this.Property(e => e.LockoutEndDateUtc)
                .HasColumnType("datetime");

            this.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(256);

            this.HasIndex(e => e.UserName)
                .HasName("UserNameIndex")
                .IsUnique();
        }
    }
}
