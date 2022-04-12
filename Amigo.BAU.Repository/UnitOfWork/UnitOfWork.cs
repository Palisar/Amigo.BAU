using Amigo.BAU.Repository.EngineerRepository;
using Amigo.BAU.Repository.Interfaces;
using System.Data;
using System.Data.Common;

namespace Amigo.BAU.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbConnection _connection;
        private readonly IEngineerRepository _repository;
        private DbTransaction _transaction;

        public UnitOfWork(DbConnection connection, IEngineerRepository repository)
        {
            _connection = connection;
            _repository = repository;
        }

        public IEngineerRepository EngineerRepository => _repository;
        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;
        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public async Task BeginAsync()
        {
            await _connection.OpenAsync();
            _transaction = await _connection.BeginTransactionAsync();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            _transaction = null;
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }

        public async Task RollBackAsync()
        {
            await _transaction.RollbackAsync();
        }
    }
}
