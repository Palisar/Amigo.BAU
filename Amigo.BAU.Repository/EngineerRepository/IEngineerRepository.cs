using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Persistance.QueryModels;
using Amigo.BAU.Repository.Interfaces;

namespace Amigo.BAU.Repository.EngineerRepository
{
    public interface IEngineerRepository : IRepository<Engineer>
    {
        IEnumerable<Engineer> GetAll();
        IEnumerable<ShiftWorker> GetNamedEngineers();
    }
}
