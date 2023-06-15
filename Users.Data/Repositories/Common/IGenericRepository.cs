using System.Linq.Expressions;
using Users.Data.Entities.Abstract;

namespace Users.Data.Repositories.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}