using Microsoft.EntityFrameworkCore;

namespace Users.Data.Common;

public static class DatabaseInitializer
{
    public static void Initialize(FavoriteLiteratureUsersDbContext context)
    {
        if (context.Database.CanConnect())
        {
            context.Database.Migrate();
        }

        if (!context.Roles.Any())
        {
            context.Roles.AddRange(DatabaseSeeds.Roles);
            context.SaveChanges();
        }

        if (!context.Users.Any())
        {
            context.Users.AddRange(DatabaseSeeds.Users);
            context.SaveChanges();
        }
    }
}