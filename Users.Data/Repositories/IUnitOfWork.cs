﻿using Users.Data.Repositories.Roles;
using Users.Data.Repositories.Users;

namespace Users.Data.Repositories;

public interface IUnitOfWork
{
    IUsersRepository UsersRepository { get; }
    IRolesRepository RolesRepository { get; }

    void Commit();
    Task CommitAsync();
    Task BeginTransactionAsync(IEnumerable<Action> actions);
    void Rollback();
    Task RollbackAsync();
}