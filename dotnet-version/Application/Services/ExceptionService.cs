using Dapper;
using Microsoft.Data.Sqlite;
using System;

namespace Application.Services
{
    public class ExceptionService
    {
        private readonly string _connectionString = "Data Source=database.sqlite";

        public void LogException(Exception ex, string? context = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "INSERT INTO Exceptions (Message, StackTrace, Context, CreatedAt) VALUES (@Message, @StackTrace, @Context, @CreatedAt);";
            connection.Execute(sql, new
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Context = context,
                CreatedAt = DateTime.UtcNow
            });
        }
    }
}
