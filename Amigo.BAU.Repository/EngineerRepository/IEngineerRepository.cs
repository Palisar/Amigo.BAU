using Amigo.BAU.Repository.Interfaces;
using Amigo.BAU.Data.Models;
using Amigo.BAU.Repository.ViewModels;

namespace Amigo.BAU.Repository.EngineerRepository
{
    public interface IEngineerRepository : IRepository<Engineer>
    {
        IEnumerable<Engineer> GetAll();
        IEnumerable<EngineerViewModel> GetNamedEngineers();
    }
}
