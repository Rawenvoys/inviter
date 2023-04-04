using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Inviter.Infrastracture
{
    public class InviterContext
    {
        private readonly string _connectionString;
        public InviterContext(IConfiguration configuration)
            => _connectionString = configuration.GetConnectionString("InviterDb") ?? throw new NullReferenceException($"Cannot find connection string with name: InviterDb");

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
