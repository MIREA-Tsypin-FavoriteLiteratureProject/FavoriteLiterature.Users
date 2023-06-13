namespace Users.Domain.Users.Responses.Queries;

public class GetAllUsersItemResponse
{
    public Guid Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTimeOffset DateOfBirth { get; set; }

    public string RoleName { get; set; } = null!;
}