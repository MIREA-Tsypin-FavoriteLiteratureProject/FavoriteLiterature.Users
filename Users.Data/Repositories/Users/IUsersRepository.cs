using Users.Data.Entities;
using Users.Data.Repositories.Common;

namespace Users.Data.Repositories.Users;

public interface IUsersRepository : IGenericRepository<User>
{
}