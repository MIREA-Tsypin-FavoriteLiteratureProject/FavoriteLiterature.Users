using Users.Data.Entities;
using Users.Data.Repositories.Common;

namespace Users.Data.Repositories.Users;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    public UsersRepository(FavoriteLiteratureUsersDbContext dbContext) : base(dbContext)
    {
    }
}