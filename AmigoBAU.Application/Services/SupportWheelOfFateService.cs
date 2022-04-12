using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Persistance.QueryModels;
using Amigo.BAU.Repository.Interfaces;

namespace Amigo.BAU.Application.Services
{
    public class SupportWheelOfFateService : ISupportWheelOfFate
    {
        private static Random random = new();
        private readonly IDateTimeProvider _date;
        private readonly ISupportTeam _team;
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _numberOfShiftWorkers;

        public SupportWheelOfFateService(IDateTimeProvider date, ISupportTeam team, IUnitOfWork unitOfWork)
        {
            _date = date;
            _team = team;
            _unitOfWork = unitOfWork;
            _numberOfShiftWorkers = 2; // change this to set the number of engineers selected for support
        }
        public async Task<IEnumerable<ShiftWorker>> WhoGoesToday()
        {
            _date.GetDay();
            if (_date.DayChanged)
            {
                _team.ResetStaff();
            }
            else if (_team.IsConfirmedToday)
            {
                return _team.Staff;
            }

            await _unitOfWork.BeginAsync();

            var whosUp = await GetAvailableShiftWorkersAsync();

            var todaysEmployees = new ShiftWorker[_numberOfShiftWorkers];

            for (int i = 0; i < _numberOfShiftWorkers; i++)
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

            _team.Staff = todaysEmployees;

            await _unitOfWork.CommitAsync();
            _unitOfWork.Dispose();
            return todaysEmployees;
        }

        private async Task<IEnumerable<ShiftWorker>> GetAvailableShiftWorkersAsync()
        {
            await ResetEngineers();
            var engineers = await _unitOfWork.EngineerRepository.GetNamedEngineers();

            var repo = engineers.Where(employee => employee.LastShift != DateTimeOffset.UtcNow.AddDays(-1));

            var haventDone2 = repo.Where(x => x.ShiftCount < 2);

            return haventDone2.ToArray().Length <= 0 ? repo : haventDone2;
        }

        private async Task ResetEngineers()
        {
            var workers = await _unitOfWork.EngineerRepository.GetAll();
            var over2weeks = workers.Where(w => w.FirstShift > _date.GetDay().AddDays(-14).Date).ToArray();

            foreach (var engineer in over2weeks)
            {
                engineer.FirstShift = null;
                engineer.LastShift = null;
                engineer.ShiftCount = 0;
            }

            await _unitOfWork.EngineerRepository.UpdateAll(over2weeks);
        }
    }
}
