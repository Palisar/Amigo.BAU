using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amigo.BAU.Repository.EngineerRepository;

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
