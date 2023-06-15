using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Data.Entities.Abstract;

namespace Users.Data.Configurations.Abstract;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}