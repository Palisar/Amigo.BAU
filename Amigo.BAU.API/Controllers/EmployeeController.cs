using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Repository.EmployeeRepository;
using Microsoft.AspNetCore.Mvc;

namespace Amigo.BAU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employee.EmployeeId = !_repo.GetAll().Any() ? 1 : _repo.GetAll().Select(x => x.EmployeeId).Max() + 1 ;
            _repo.Add(employee);
            
            return Ok(employee);
        }
    }
}
