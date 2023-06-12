using System.ComponentModel.DataAnnotations;
using MediatR;
using Users.Domain.Authentication.Responses.Commands;

namespace Users.Domain.Authentication.Requests.Commands;

public class AuthenticationCommand : IRequest<AuthenticationResponse>
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}