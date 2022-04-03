using Amigo.BAU.Repository.Interfaces;
using Amigo.BAU.Persistance.Models;

namespace Amigo.BAU.Repository.EmployeeRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAll();
    }
}
