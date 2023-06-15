using System.ComponentModel.DataAnnotations;
using MediatR;
using Users.Domain.Registration.Responses.Commands;

namespace Users.Domain.Registration.Requests.Commands;

public class RegistrationCommand : IRequest<RegistrationResponse>
{
    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = null!;
    
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    public string PasswordConfirmation { get; set; } = null!;

    public DateTimeOffset DateOfBirth { get; set; }
}