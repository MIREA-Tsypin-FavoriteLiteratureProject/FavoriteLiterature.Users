using Users.Data.Entities.Abstract;

namespace Users.Data.Entities;

public sealed class User : BaseEntity
{
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTimeOffset DateOfBirth { get; set; }

    public string RoleId { get; set; } = null!;
    public Role Role { get; set; }

    public User SetPassword(string password)
    {
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        return this;
    }
}