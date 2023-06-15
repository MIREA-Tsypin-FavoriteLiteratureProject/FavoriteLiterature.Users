using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Policies;
using Users.Domain.Authentication.Requests.Commands;
using Users.Domain.Authentication.Responses.Commands;
using Users.Domain.Registration.Requests.Commands;
using Users.Domain.Registration.Responses.Commands;
using Users.Domain.Users.Requests.Queries;
using Users.Domain.Users.Responses.Queries;

namespace Users.API.Controllers;

public class UsersController : BaseApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpPost("registration")]
    public async Task<RegistrationResponse> RegisterAsync(RegistrationCommand command, CancellationToken cancellationToken)
        => await _mediator.Send(command, cancellationToken);

    [AllowAnonymous]
    [HttpPost("authentication")]
    public async Task<AuthenticationResponse> GetTokenAsync(AuthenticationCommand command, CancellationToken cancellationToken) 
        => await _mediator.Send(command, cancellationToken);

    [HttpGet("current")]
    public async Task<GetUserResponse> GetCurrentUserAsync(CancellationToken cancellationToken) 
        => await _mediator.Send(new GetUserQuery(GetCurrentUserId()), cancellationToken);

    [HttpGet("{id:guid}")]
    [Authorize(Policy = nameof(RolePolicy.Critic))]
    public async Task<GetUserResponse> GetAsync(Guid id, CancellationToken cancellationToken) 
        => await _mediator.Send(new GetUserQuery(id), cancellationToken);

    [HttpGet]
    [Authorize(Policy = nameof(RolePolicy.Critic))]
    public async Task<GetAllUsersResponse> GetAllAsync([FromQuery] GetAllUsersQuery query, CancellationToken cancellationToken)
        => await _mediator.Send(query, cancellationToken);
}