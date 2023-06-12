namespace Users.Data.Entities;

public class Role
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<User> Users { get; } = new List<User>();
}