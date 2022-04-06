using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Persistance.QueryModels;
using Amigo.BAU.Repository.EngineerRepository;

namespace Amigo.BAU.Application.Services
{
    public class SupportWheelOfFateService
    {
        private static Random random = new();
        private readonly IDateTimeProvider _date;
        private DateTimeOffset today;
        private readonly IEngineerRepository _repository;
        private IEnumerable<ShiftWorker> todaysStaff;

        public SupportWheelOfFateService(IDateTimeProvider date, IEngineerRepository repository)
        {
            _date = date;
            _repository = repository;
        }
        public async Task<IEnumerable<ShiftWorker>> WhoGoesToday(int numberOfShiftWorkers)
        {
            if (today.Date == _date.GetDay())
            {
                return todaysStaff;
            }
            today = _date.GetDay();

            // if day has not yet passed the just return the current list of employees
            var engineeers = _repository.GetNamedEngineers();
            //gets a list of workers who did work yesterday
            var whoWorked = engineeers.Where(shiftWorker => shiftWorker.LastShift == DateTimeOffset.UtcNow.AddDays(-1));

            //gets a list of workers who did not work
            var repo = engineeers.Where(employee => employee.LastShift != DateTimeOffset.UtcNow.AddDays(-1));

            //check for anyone who might not have worked yet
            var whosUp = repo.Where(x => x.ShiftCount < 2);
            
            if (whosUp.Count() <= 0)
            {
                whosUp = repo;
            }

            //creates output array 
            var todaysEmployees = new ShiftWorker[numberOfShiftWorkers];

            // use a rules engine pattern for each employee to see if they can be assigned as well once you have randomly selected them
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
                };
                if (employee.FirstShift is null)
                {
                    engineerToUpdate.FirstShift = _date.GetDay();
                }
                engineerToUpdate.LastShift = _date.GetDay();
                employee.ShiftCount++;
                _repository.Update(engineerToUpdate, engineerToUpdate.EngineerId);
                todaysEmployees[i] = employee;
            }

            await WorkerCycleCheck(whoWorked);
            return todaysEmployees;
        }
    }
}
