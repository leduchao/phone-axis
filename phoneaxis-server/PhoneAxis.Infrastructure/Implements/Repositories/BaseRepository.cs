using Microsoft.EntityFrameworkCore;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace PhoneAxis.Infrastructure.Implements.Repositories;

public class BaseRepository<T>(PhoneAxisDbContext dbContext) : IBaseRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool includeDeleted = false)
    {
        if (includeDeleted) return await _dbSet.ToListAsync();
        else return await _dbSet.Where(p => !p.IsDeleted).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllWithConditionAsync(Expression<Func<T, bool>> condition)
    {
        return await _dbSet.Where(condition).ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
    }

    public async Task<T> GetFirstByConditionAsync(Expression<Func<T, bool>> condition)
    {
        return await _dbSet.FirstOrDefaultAsync(condition)
               ?? throw new KeyNotFoundException("No entity found matching the specified condition.");
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }
}
