using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Application.Interfaces.Services;
using PhoneAxis.Domain.Entities;
using System.Linq.Expressions;

namespace PhoneAxis.Infrastructure.Implements.Services;

public class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T> where T : BaseEntity
{
    private readonly IBaseRepository<T> _repository = repository;
    public readonly IBaseRepository<T> Repository = repository;

    public async Task AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _repository.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool includeDeleted = false)
    {
        return await _repository.GetAllAsync(includeDeleted);
    }

    public async Task<IEnumerable<T>> GetAllWithConditionAsync(Expression<Func<T, bool>> condition)
    {
        return await _repository.GetAllWithConditionAsync(condition);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<T> GetFirstByConditionAsync(Expression<Func<T, bool>> condition)
    {
        return await _repository.GetFirstByConditionAsync(condition);
    }

    public void Remove(T entity)
    {
        _repository.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _repository.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _repository.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _repository.UpdateRange(entities);
    }
}
