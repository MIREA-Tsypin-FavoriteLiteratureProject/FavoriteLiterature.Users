using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Data.Common;
using Users.Data.Configurations.Abstract;
using Users.Data.Entities;

namespace Users.Data.Configurations;

public sealed class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(UsersApiTables.Users);
        builder.HasKey(x => x.Id).HasName($"{UsersApiTables.Users}_pkey");
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
        builder.Property(x => x.PasswordHash).HasColumnName("password_hash").IsRequired();
        builder.Property(x => x.DateOfBirth).HasColumnName("date_of_birth");
        builder.Property(x => x.RoleId).HasColumnName($"{UsersApiTables.Roles}_id").IsRequired();

        builder
            .HasOne(user => user.Role)
            .WithMany(role => role.Users)
            .HasForeignKey(x => x.RoleId);
    }
}