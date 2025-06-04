namespace PhoneAxis.Application.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
