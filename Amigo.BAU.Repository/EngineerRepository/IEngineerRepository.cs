using Amigo.BAU.Repository.Interfaces;
using Amigo.BAU.Repository.Models;

namespace Amigo.BAU.Repository.EngineerRepository
{
    public interface IEngineerRepository : IRepository<Engineer>
    {
        IEnumerable<Engineer> GetAll();
    }
}
