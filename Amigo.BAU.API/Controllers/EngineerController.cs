using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Persistance.QueryModels;
using Amigo.BAU.Repository.EmployeeRepository;
using Amigo.BAU.Repository.EngineerRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amigo.BAU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EngineerController : ControllerBase
    {
        private readonly IEngineerRepository _engineerRepository;
     
        public EngineerController(IEngineerRepository engineerRepository)
        {
            _engineerRepository = engineerRepository;
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
        public ActionResult<IEnumerable<ShiftWorker>> GetNamedEngineers()
        {
            var engineers = _engineerRepository.GetNamedEngineers();
            if (engineers is null)
            {
                return BadRequest();
            }
            return Ok(engineers);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<Engineer> AddEngineer(Engineer engineer)
        {
            var result = _engineerRepository.Add(engineer);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
// dont forget to move this logic into the service layer and call abstactions of those services
