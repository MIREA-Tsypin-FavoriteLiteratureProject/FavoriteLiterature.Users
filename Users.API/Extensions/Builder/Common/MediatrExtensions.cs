using MediatR;
using Users.Application.Handlers.Common.Authentication.Commands;
using Users.Application.Handlers.Common.Registration.Commands;
using Users.Domain.Authentication.Requests.Commands;
using Users.Domain.Authentication.Responses.Commands;
using Users.Domain.Registration.Requests.Commands;
using Users.Domain.Registration.Responses.Commands;

namespace Users.API.Extensions.Builder.Common;

public static class MediatrExtensions
{
    public static void AddMediatr(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(_ => _.RegisterServicesFromAssemblies(typeof(Program).Assembly));

        builder.Services.AddTransient<IRequestHandler<RegistrationCommand, RegistrationResponse>, RegistrationCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<AuthenticationCommand, AuthenticationResponse>, AuthenticationCommandHandler>();
    }
}