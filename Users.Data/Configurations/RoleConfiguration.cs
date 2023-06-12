using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Data.Common;
using Users.Data.Entities;

namespace Users.Data.Configurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(UsersApiTables.Roles);
        builder.HasKey(x => x.Name).HasName($"{UsersApiTables.Roles}_pkey");

        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(50);
    }
}