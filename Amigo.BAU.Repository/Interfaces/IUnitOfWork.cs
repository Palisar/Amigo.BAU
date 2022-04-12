using Amigo.BAU.Repository.EngineerRepository;
using System.Data;

namespace Amigo.BAU.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IEngineerRepository EngineerRepository { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        Task BeginAsync();
        void Commit();
        Task CommitAsync();
        void Dispose();
        void RollBack();
        Task RollBackAsync();
    }
}
