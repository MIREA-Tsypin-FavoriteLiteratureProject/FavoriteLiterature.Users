using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Users.Application.Options;

namespace Users.API.Extensions.Builder.Common;

public static class AuthenticationExtensions
{
    public static AuthenticationBuilder AddJwtBearerAuthentication(this AuthenticationBuilder builder, 
        IConfiguration configuration)
    {
        builder.Services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

        var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

        builder.AddJwtBearer(options =>
        {
            options.IncludeErrorDetails = true;
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtOptions!.Issuer,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        return builder;
    }
}