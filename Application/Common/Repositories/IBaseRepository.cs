using Application.Common.Models;
using Domain.Common;
using System.Linq.Expressions;

namespace Application.Common.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> Create(T entity, CancellationToken cancellationToken);
    Task<T> GetById(int Id, CancellationToken cancellationToken);
    Task<T?> GetDefaultById(int Id, CancellationToken cancellationToken);
    void Update(T entity);
    Task<PaginatedList<T>> GetPaginated(PaginationInput pagination, CancellationToken cancellationToken);
    // Query methods
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    // Command methods
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteAsync(int id);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task DeleteRangeAsync(IEnumerable<int> ids);

    // Query with includes
    Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task<T?> GetByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> FindWithIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);


}
