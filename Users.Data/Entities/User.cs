using Users.Data.Entities.Abstract;

namespace Users.Data.Entities;

public sealed class User : BaseEntity
{
    public Guid Id { get; init; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTimeOffset DateOfBirth { get; set; }

    public string RoleName { get; set; } = "user";
    public Role Role { get; set; }

    public User()
        => Id = Guid.NewGuid();

    public User SetPassword(string password)
    {
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        return this;
    }
}