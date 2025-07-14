using System.Data;

namespace PhoneAxis.Application.Interfaces;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}
