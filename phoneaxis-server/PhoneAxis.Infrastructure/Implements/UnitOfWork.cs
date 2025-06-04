using PhoneAxis.Application.Interfaces;
using PhoneAxis.Infrastructure.Persistence;

namespace PhoneAxis.Infrastructure.Implements;

public class UnitOfWork(PhoneAxisDbContext dbContext) : IUnitOfWork
{
    private readonly PhoneAxisDbContext _dbContext = dbContext;

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
