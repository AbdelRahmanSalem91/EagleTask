using EagleTask.Models.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EagleTask.Data.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id)
                .HasName("PK_UserKey");
            builder
                .Property(u => u.UserName)
                .IsRequired();
            builder
                .Property(u => u.Password)
                .IsRequired();

            builder
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UsersRoles>(
                    j => j.HasOne(ur => ur.Role)
                         .WithMany(r => r.UsersRoles)
                         .HasForeignKey(ur => ur.RoleId)
                         .HasConstraintName("FK_UsersRoles_Role"),
                    j => j.HasOne(ur => ur.User)
                         .WithMany(u => u.UsersRoles)
                         .HasForeignKey(ur => ur.UserId)
                         .HasConstraintName("FK_UsersRoles_User"),
                    j =>
                    {
                        j
                        .Property(po => po.AddedOn)
                        .HasDefaultValueSql("GETDATE()");

                        j
                        .HasKey(po => new { po.UserId, po.RoleId });
                    }
                );

            builder
                .HasOne(e => e.Manager)
                .WithMany(e => e.SubUsers)
                .HasForeignKey(e => e.ManagerId)
                .HasConstraintName("FK_UserManagerKey")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
