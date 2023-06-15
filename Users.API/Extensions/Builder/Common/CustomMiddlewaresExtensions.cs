using Users.API.Middlewares;

namespace Users.API.Extensions.Builder.Common;

public static class CustomMiddlewaresExtensions
{
    public static void AddCustomMiddlewares(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ExceptionHandlingMiddleware>();
    }
}