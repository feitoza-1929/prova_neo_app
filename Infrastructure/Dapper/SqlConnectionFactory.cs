using Domain.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Dapper;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public SqlConnection Create()
    {
        return new SqlConnection(
            _configuration.GetConnectionString("SqlServer"));
    }
}