using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Repository.Interfaces;

namespace Amigo.BAU.Repository.EmployeeRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAll();
    }
}
