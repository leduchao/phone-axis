using Dapper;
using Microsoft.EntityFrameworkCore;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Application.Interfaces.Repositories;
using PhoneAxis.Domain.Entities;
using PhoneAxis.Infrastructure.Persistence;
using System.Data;
using System.Linq.Expressions;

namespace PhoneAxis.Infrastructure.Implements.Repositories;

public class BaseRepository<T>(PhoneAxisDbContext dbContext, IDbConnectionFactory connectionFactoory) : IBaseRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    // using dapper for GET queries
    private readonly string _tableName = GetTableName(dbContext);
    private readonly IDbConnectionFactory _connectionFactory = connectionFactoory;

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<IList<T>> GetAllAsync(bool includeDeleted = false)
    {
        if (includeDeleted) return await _dbSet.ToListAsync();
        return await _dbSet.Where(p => !p.IsDeleted).ToListAsync();
    }

    public async Task<IList<TResult>> GetAllProjected<TResult>(Expression<Func<T, TResult>> projection, bool includeDeleted = false)
    {
        IQueryable<T> query = _dbSet;
        if (!includeDeleted) query = query.Where(p => !p.IsDeleted);
        return await query.Select(projection).ToListAsync();
    }

    public async Task<IList<TResult>> GetAllProjected<TResult>(string selectColumns, string? whereClause = null, object? parameters = null, bool includeDeleted = false)
    {
        var sql = $"SELECT {selectColumns} FROM {_tableName}";

        if (!includeDeleted) sql += $" WHERE IsDeleted = 0";

        if (!string.IsNullOrWhiteSpace(whereClause))
            sql += $" WHERE {whereClause}";

        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.QueryAsync<TResult>(sql, parameters);

        return [.. result];
    }

    public async Task<IList<T>> GetAllWithConditionAsync(Expression<Func<T, bool>> condition)
    {
        return await _dbSet.Where(condition).ToListAsync();
    }

    public async Task<IList<TResult>> GetAllWithConditionProjectedAsync<TResult>(Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> projection)
    {
        return await _dbSet.Where(condition).Select(projection).ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
    }

    public async Task<TResult> GetByIdProjectedAsync<TResult>(Guid id, Expression<Func<T, TResult>> projection)
    {
        return await _dbSet.Where(e => e.Id == id).Select(projection).FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
    }

    public async Task<T> GetFirstByConditionAsync(Expression<Func<T, bool>> condition)
    {
        return await _dbSet.FirstOrDefaultAsync(condition)
            ?? throw new KeyNotFoundException("No entity found matching the specified condition.");
    }

    public async Task<TResult> GetFirstByConditionProjectedAsync<TResult>(Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> projection)
    {
        return await _dbSet.Where(condition).Select(projection).FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("No entity found matching the specified condition.");
    }

    public IQueryable GetQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public void Remove(T entity, bool isSoftDelete = false)
    {
        if (isSoftDelete)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }
        else
        {
            _dbSet.Remove(entity);
        }
    }

    public void RemoveRange(IEnumerable<T> entities, bool isSoftDelete = false)
    {
        if (isSoftDelete)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
            }

            _dbSet.UpdateRange(entities);
        }
        else
        {
            _dbSet.RemoveRange(entities);
        }
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            entity.UpdatedAt = DateTime.UtcNow;
        }

        _dbSet.UpdateRange(entities);
    }

    private static string GetTableName(PhoneAxisDbContext dbContext)
    {
        var entityType =  dbContext.Model.FindEntityType(typeof(T))
            ?? throw new InvalidOperationException($"Entity type '{typeof(T).Name}' is not part of the EF Core model. Make sure it's added via DbSet<T> or configured in OnModelCreating().");

        var tableName = entityType.GetTableName()
            ?? throw new InvalidOperationException($"Cannot determine table name for entity '{typeof(T).Name}'.");

        var schema = entityType.GetSchema();

        return string.IsNullOrWhiteSpace(schema) ? tableName : $"{schema}.{tableName}" ;
    }
}
