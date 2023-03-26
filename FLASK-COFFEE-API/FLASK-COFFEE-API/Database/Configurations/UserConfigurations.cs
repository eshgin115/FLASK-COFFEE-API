using FLASK_COFFEE_API.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FLASK_COFFEE_API.Database.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
           .ToTable("Users");

     

        builder
           .HasOne(u => u.Role)
           .WithMany(r => r.Users)
           .HasForeignKey(u => u.RoleId);

        builder
            .HasOne(u => u.UserActivation)
            .WithOne(ua => ua.User)
            .HasForeignKey<UserActivation>(ua => ua.UserId);
    }
}