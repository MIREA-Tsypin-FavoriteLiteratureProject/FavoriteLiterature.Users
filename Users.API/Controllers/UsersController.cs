using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Domain.Authentication.Requests.Commands;
using Users.Domain.Authentication.Responses.Commands;
using Users.Domain.Registration.Requests.Commands;
using Users.Domain.Registration.Responses.Commands;

namespace Users.API.Controllers;

public class UsersController : BaseApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpPost("registration")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<RegistrationResponse> RegisterAsync(RegistrationCommand command, CancellationToken cancellationToken)
        => await _mediator.Send(command, cancellationToken);

    [AllowAnonymous]
    [HttpPost("authentication")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<AuthenticationResponse> GetTokenAsync(AuthenticationCommand command, CancellationToken cancellationToken) 
        => await _mediator.Send(command, cancellationToken);
}