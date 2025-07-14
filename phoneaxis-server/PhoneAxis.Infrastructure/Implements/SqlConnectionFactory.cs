using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PhoneAxis.Application.Interfaces;
using PhoneAxis.Infrastructure.Constants;
using System.Data;

namespace PhoneAxis.Infrastructure.Implements;

public class SqlConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
{
    private readonly string _connectionString = configuration.GetConnectionString(ConnectionStringConstant.SQL_SERVER)
        ?? throw new ArgumentNullException(ConnectionError.CONNECTION_STR_NOT_CONFIGURED);

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}
