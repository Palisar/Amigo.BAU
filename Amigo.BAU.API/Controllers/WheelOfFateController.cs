using Amigo.BAU.Application.Services;
using Amigo.BAU.Persistance.QueryModels;
using Amigo.BAU.Repository.EngineerRepository;
using Microsoft.AspNetCore.Mvc;

namespace Amigo.BAU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WheelOfFateController : ControllerBase
    {
        private readonly ISupportWheelOfFateService _wheelOfFate;

        public WheelOfFateController(ISupportWheelOfFateService wheelOfFate )
        {
            _wheelOfFate = wheelOfFate;
        }
        [HttpGet]
        public IActionResult WheelOfFate(int staffNeeded)
        {
            var shiftWorkers = _wheelOfFate.WhoGoesToday(staffNeeded);
            return Ok(shiftWorkers);
        }
    }
}
