namespace Users.Data.Entities.Abstract;

public abstract class BaseEntity
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public Guid Id { get; private set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}