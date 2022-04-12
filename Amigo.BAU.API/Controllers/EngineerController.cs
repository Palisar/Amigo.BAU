using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Repository.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Amigo.BAU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EngineerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupportTeam _team;

        public EngineerController(IUnitOfWork unitOfWork, ISupportTeam team)
        {
            _unitOfWork = unitOfWork;
            _team = team;
        }

        [HttpPut]
        [Route("updateEngineers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<HttpResponseMessage> UpdateEngineers()
        {
            if (_team.Staff is null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return response;
            }

            _team.ConfirmTodaysStaff();
            var staffToUpdate = _team.Staff.ToArray();
            var mappedStaff = new Engineer[2];

            for (int i = 0; i < staffToUpdate.Length; i++)
            {
                mappedStaff[i] = staffToUpdate[i].Adapt<Engineer>();
            }

            await _unitOfWork.BeginAsync();
            await _unitOfWork.EngineerRepository.UpdateAll(mappedStaff);
            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
