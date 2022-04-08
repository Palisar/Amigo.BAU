using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Persistance.QueryModels;
using Amigo.BAU.Repository.EngineerRepository;

namespace Amigo.BAU.Application.Services
{
    public class SupportWheelOfFateService : ISupportWheelOfFate
    {
        private readonly Random random = new();
        private readonly IDateTimeProvider _date;
        private readonly ISupportTeam _team;
        private readonly IEngineerRepository _repository;
        private readonly int numberOfShiftWorkers;

        public SupportWheelOfFateService(IDateTimeProvider date, IEngineerRepository repository, ISupportTeam team)
        {
            _date = date;
            _repository = repository;
            _team = team;
            numberOfShiftWorkers = 2; // change this to set the number of engineers selected for support
        }
        public async Task<IEnumerable<ShiftWorker>> WhoGoesToday()
        {
            _date.GetDay();
            if (!_date.DayChanged)
            {
                return _team.Staff;
            }

            // if day has not yet passed the just return the current list of employees
            var engineers = _repository.GetNamedEngineers();
            //gets a list of workers who did work yesterday
            var whoWorked = engineers.Where(shiftWorker => shiftWorker.LastShift == DateTimeOffset.UtcNow.AddDays(-1));

            //gets a list of workers who did not work
            var repo = engineers.Where(employee => employee.LastShift != DateTimeOffset.UtcNow.AddDays(-1));

            //check for anyone who might not have worked yet
            var whosUp = repo.Where(x => x.ShiftCount < 2);

            if (whosUp.ToArray().Length <= 0)
            {
                whosUp = repo;
            }

            //creates output array 
            var todaysEmployees = new ShiftWorker[numberOfShiftWorkers];

            // TODO : use a rules engine pattern for each employee to see if they can be assigned as well once you have randomly selected them
            for (int i = 0; i < numberOfShiftWorkers; i++)
            {
                var employeeIndex = random.Next(0, whosUp.Count());

                if (todaysEmployees.Contains(whosUp.ElementAt(employeeIndex)))
                {
                    i--;
                    continue;
                }

                var employee = whosUp.ElementAt(employeeIndex);
                var engineerToUpdate = new Engineer
                {
                    EngineerId = employee.EngineerId,
                    ShiftCount = employee.ShiftCount == null ? 1 : employee.ShiftCount++,
                };
                //if (employee.FirstShift == null)
                //{
                //    engineerToUpdate.FirstShift = _date.GetDay();
                //}
                //else
                //{
                //    engineerToUpdate.FirstShift = employee.FirstShift;
                //}
                engineerToUpdate.FirstShift = employee.FirstShift == null ? _date.GetDay() : employee.FirstShift;

                engineerToUpdate.LastShift = _date.GetDay();
                _repository.Update(engineerToUpdate, engineerToUpdate.EngineerId);
                todaysEmployees[i] = employee;
            }

            _team.Staff = todaysEmployees;
            //await WorkerCycleCheck(todaysEmployees); TODO : need to make this its own method that takes in the whole repo after everything else is done and resets anyone whos first shift was 2 weeks ago
            return todaysEmployees;
        }
    }
}
