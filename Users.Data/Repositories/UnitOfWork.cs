using Users.Data.Repositories.Roles;
using Users.Data.Repositories.Users;

namespace Users.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FavoriteLiteratureUsersDbContext _dbContext;

    public IUsersRepository UsersRepository { get; }
    public IRolesRepository RolesRepository { get; }

    public UnitOfWork(FavoriteLiteratureUsersDbContext dbContext, IUsersRepository usersRepository, IRolesRepository rolesRepository)
    {
        _dbContext = dbContext;
        UsersRepository = usersRepository;
        RolesRepository = rolesRepository;
    }

    public void Commit()
        => _dbContext.SaveChanges();

    public async Task CommitAsync()
        => await _dbContext.SaveChangesAsync();

    public async Task BeginTransactionAsync(IEnumerable<Action> actions)
    {
        try
        {
            foreach (var action in actions)
            {
                action();
            }
            await CommitAsync();
        }
        catch (Exception)
        {
            await RollbackAsync();
            throw;
        }
    }

    public void Rollback()
        => _dbContext.Dispose();

    public async Task RollbackAsync()
        => await _dbContext.DisposeAsync();
}