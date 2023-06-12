using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Users.API.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected Guid GetCurrentUserId()
    {
        if (Guid.TryParse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value, out var userId))
        {
            return userId;
        }

        throw new Exception("User is not found!");
    }
}