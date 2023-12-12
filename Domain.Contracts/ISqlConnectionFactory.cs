
using Microsoft.Data.SqlClient;

namespace Domain.Contracts;

public interface ISqlConnectionFactory
{
    SqlConnection Create();
}