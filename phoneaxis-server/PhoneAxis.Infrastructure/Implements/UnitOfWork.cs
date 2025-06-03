using PhoneAxis.Application.Interfaces;
using PhoneAxis.Infrastructure.Persistence;

namespace PhoneAxis.Infrastructure.Implements;

public class UnitOfWork(PhoneAxisDbContext dbContext) : IUnitOfWork
{
    private readonly PhoneAxisDbContext _dbContext = dbContext;

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
