using AutoMapper;
using Users.Application.Mapping;

namespace Users.API.Extensions.Builder.Common;

public static class AutoMapperExtensions
{
    public static void AddAutoMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMapper>(_ =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            return config.CreateMapper();
        });
    }
}