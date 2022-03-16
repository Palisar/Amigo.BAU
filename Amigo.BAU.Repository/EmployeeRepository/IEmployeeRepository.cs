using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Application.Models;

namespace Amigo.BAU.Repository.EmployeeRepository
{
    public interface IEmployeeRepository : IRepository<EmployeeModel>
    {
        IEnumerable<EmployeeModel> GetAll();
    }
}
