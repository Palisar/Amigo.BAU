using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Persistance.QueryModels;
using Amigo.BAU.Repository.Interfaces;
using System.Linq;

namespace Amigo.BAU.Application.Services
{
    public class SupportWheelOfFateService : ISupportWheelOfFate
    {
        private readonly Random random = new();
        private readonly IDateTimeProvider _date;
        private readonly ISupportTeam _team;
        private readonly IUnitOfWork _unitOfWork;
        private readonly int numberOfShiftWorkers;

        public SupportWheelOfFateService(IDateTimeProvider date, ISupportTeam team, IUnitOfWork unitOfWork)
        {
            _date = date;
            _team = team;
            _unitOfWork = unitOfWork;
            numberOfShiftWorkers = 2; // change this to set the number of engineers selected for support
        }
        public async Task<IEnumerable<ShiftWorker>> WhoGoesToday()
            {
            _date.GetDay();

            await _unitOfWork.BeginAsync();
            
            var whosUp = await GetAvailableShiftWorkersAsync();

            var todaysEmployees = new ShiftWorker[numberOfShiftWorkers];
            
            for (int i = 0; i < numberOfShiftWorkers; i++)
            {
                var employeeIndex = random.Next(0, whosUp.Count());
                var employee = whosUp.ElementAt(employeeIndex);
                if (todaysEmployees.Contains(employee))
                {
                    i--;
                    continue;
                }

                todaysEmployees[i] = employee;
            }

            await _unitOfWork.CommitAsync();
            _team.Staff = todaysEmployees;
            
            _unitOfWork.Dispose();
            return todaysEmployees;
        }

        private async Task<IEnumerable<ShiftWorker>> GetAvailableShiftWorkersAsync()
        {
            await ResetEngineers();
            var engineers =await _unitOfWork.EngineerRepository.GetNamedEngineers();
            
            var repo = engineers.Where(employee => employee.LastShift != DateTimeOffset.UtcNow.AddDays(-1));
            
            var haventDone2 = repo.Where(x => x.ShiftCount < 2);

            return haventDone2.ToArray().Length <= 0 ? repo : haventDone2;
        }

        private async Task ResetEngineers()
        {
            var workers = await _unitOfWork.EngineerRepository.GetAll();
            var over2weeks = workers.Where(w => w.FirstShift > _date.GetDay().AddDays(-14).Date);

            foreach (var engineer in over2weeks)
            {
                engineer.FirstShift = null;
                engineer.LastShift = null;
                engineer.ShiftCount = 0;
            }

            await _unitOfWork.EngineerRepository.UpdateAll(over2weeks);
        }

        public async Task UpdateWhoWorked()
        {
            _date.GetDay();
            if (_date.DayChanged)
            {
                return;
            }
            var workers = _team.Staff;
            foreach (ShiftWorker employee in workers)
            {
                var engineerToUpdate = new Engineer
                {
                    EngineerId = employee.EngineerId,
                    ShiftCount = employee.ShiftCount == null ? 1 : employee.ShiftCount + 1,
                };

                engineerToUpdate.FirstShift = employee.FirstShift == null ? _date.GetDay() : employee.FirstShift;

                engineerToUpdate.LastShift = _date.GetDay();
                await _unitOfWork.EngineerRepository.Update(engineerToUpdate, engineerToUpdate.EngineerId);
            }
        }
    }
}
