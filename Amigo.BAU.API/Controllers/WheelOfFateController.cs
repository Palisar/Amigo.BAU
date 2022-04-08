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
        private readonly ISupportWheelOfFate _wheelOfFate;

        public WheelOfFateController(ISupportWheelOfFate wheelOfFate )
        {
            _wheelOfFate = wheelOfFate;
        }
        [HttpGet]
        public async Task<IActionResult> WheelOfFate()
        {
            var shiftWorkers = await _wheelOfFate.WhoGoesToday();
            return Ok(shiftWorkers);
        }
    }
}
