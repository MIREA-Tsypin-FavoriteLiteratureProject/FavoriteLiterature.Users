using Users.Data.Repositories;
using Users.Data.Repositories.Users;

namespace Users.API.Extensions.Builder;

public static class RepositoryExtensions
{
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}