using Microsoft.Data.Sqlite;
using System.Data;

namespace Infrastructure.Persistence.AdoNet.Context
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;
        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}
