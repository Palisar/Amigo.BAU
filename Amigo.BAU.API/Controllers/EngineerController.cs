using Amigo.BAU.Data.Models;
using Amigo.BAU.Repository.EmployeeRepository;
using Amigo.BAU.Repository.EngineerRepository;
using Amigo.BAU.Repository.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Amigo.BAU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EngineerController : ControllerBase
    {
        private readonly IEngineerRepository _engineerRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EngineerController(IEngineerRepository engineerRepository, IEmployeeRepository employeeRepository)
        {
            _engineerRepository = engineerRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Engineer>> GetEngineers()
        {
            var engineers = _engineerRepository.GetAll();

            if (engineers is null)
                return BadRequest();

            return Ok(engineers);
        }

        [HttpGet]
        [Route("GetNamed")]
        public ActionResult<IEnumerable<EngineerViewModel>> GetNamedEngineers()
        {
            var engineers = _engineerRepository.GetNamedEngineers();
            if (engineers is null)
            {
                return BadRequest();
            }
            return Ok(engineers);
        }
    }
}
// dont forget to move this logic into the service layer and call abstactions of those services
