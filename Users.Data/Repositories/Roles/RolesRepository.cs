using Users.Data.Entities;
using Users.Data.Repositories.Common;

namespace Users.Data.Repositories.Roles;

public class RolesRepository : GenericRepository<Role>, IRolesRepository
{
    public RolesRepository(FavoriteLiteratureUsersDbContext dbContext) : base(dbContext)
    {
    }
}