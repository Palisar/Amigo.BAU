using Amigo.BAU.Application.Services;
using Amigo.BAU.Persistance.QueryModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Amigo.BAU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WheelOfFateController : ControllerBase
    {
        private readonly ISupportWheelOfFate _wheelOfFate;

        public WheelOfFateController(ISupportWheelOfFate wheelOfFate)
        {
            _wheelOfFate = wheelOfFate;
        }
        [HttpGet]
        public async Task<ActionResult> WheelOfFate()
        {
            var workers = await _wheelOfFate.WhoGoesToday();

            if (workers is null)
            {
                return BadRequest();
            }

            List<ShiftWorkerResponse> responses = new();
            foreach (var shiftWorkerResponse in workers)
            {
                responses.Add(shiftWorkerResponse.Adapt<ShiftWorkerResponse>());

            }
            return Ok(responses);
        }
    }
}
