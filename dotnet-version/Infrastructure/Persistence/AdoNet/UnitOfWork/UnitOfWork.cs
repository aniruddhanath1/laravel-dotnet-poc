using System.Data;

namespace Infrastructure.Persistence.AdoNet.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly IDbConnection _connection;
        private IDbTransaction? _transaction;
        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }
        public void Commit()
        {
            _transaction?.Commit();
        }
        public void Rollback()
        {
            _transaction?.Rollback();
        }
        public void Dispose()
        {
            _transaction?.Dispose();
            _connection.Dispose();
        }
    }
}
