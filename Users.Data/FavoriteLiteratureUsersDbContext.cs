﻿using Microsoft.EntityFrameworkCore;
using Users.Data.Configurations;
using Users.Data.Entities;

namespace Users.Data;

public sealed class FavoriteLiteratureUsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Role> Roles { get; set; } = null!;

    public FavoriteLiteratureUsersDbContext(DbContextOptions<FavoriteLiteratureUsersDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        new RoleConfiguration().Configure(modelBuilder.Entity<Role>());
        base.OnModelCreating(modelBuilder);
    }
}