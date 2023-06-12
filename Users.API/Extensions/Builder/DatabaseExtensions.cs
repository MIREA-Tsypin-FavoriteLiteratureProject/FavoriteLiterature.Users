using Microsoft.EntityFrameworkCore;
using Users.Data;

namespace Users.API.Extensions.Builder;

public static class DatabaseExtensions
{
    public static void AddPostgresDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Connection string is missing.");
        }

        builder.Services.AddDbContext<FavoriteLiteratureUsersDbContext>(options => options.UseNpgsql(connectionString));
    }
}