using Users.Data.Entities.Abstract;

namespace Users.Data.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; } = null!;

    public int Weight { get; set; }

    public string? Description { get; set; }

    public ICollection<User> Users { get; } = new List<User>();
}