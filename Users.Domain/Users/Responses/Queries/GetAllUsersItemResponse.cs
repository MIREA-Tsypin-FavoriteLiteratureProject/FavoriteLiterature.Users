namespace Users.Domain.Users.Responses.Queries;

public class GetAllUsersItemResponse
{
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTimeOffset DateOfBirth { get; set; }

    public string RoleId { get; set; } = null!;
}