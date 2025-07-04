using PhoneAxis.Domain.Entities;
using System.Linq.Expressions;

namespace PhoneAxis.Application.Interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(Guid id);

    Task<TResult> GetByIdProjectedAsync<TResult>(Guid id, Expression<Func<T, TResult>> projection);

    Task<T> GetFirstByConditionAsync(Expression<Func<T, bool>> condition);

    Task<TResult> GetFirstByConditionProjectedAsync<TResult>(Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> projection);

    Task<IList<T>> GetAllAsync(bool includeDeleted = false);

    Task<IList<TResult>> GetAllProjected<TResult>(Expression<Func<T, TResult>> projection, bool includeDeleted = false);

    Task<IList<T>> GetAllWithConditionAsync(Expression<Func<T, bool>> condition);

    Task<IList<TResult>> GetAllWithConditionProjectedAsync<TResult>(Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> projection);

    IQueryable GetQueryable();

    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    void Update(T entity);

    void UpdateRange(IEnumerable<T> entities);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);
}
