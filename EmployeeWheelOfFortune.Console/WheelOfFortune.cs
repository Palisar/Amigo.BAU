using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeWheelOfFortune.Console
{
    public class WheelOfFortune
    {
        private readonly IEmployeeRepository _employeeRepository;
        private static Random random = new();
        //private readonly IDateTimeProvider _dateTime;   <--- add this to the real class   and replace everywhere that calls for DateTimeOffset to _dateTime

        public WheelOfFortune(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        /// <summary>
        /// This method will spin the wheel of fortune and return a number of random employees
        /// </summary>
        /// <param name="numberOfShiftWorkers">The number of emploees required</param>
        /// <returns>An Enumerable of Employees</returns>
        public IEnumerable<Employee> WhoGoesToday(int numberOfShiftWorkers)
        {
            // if day has not yet passed the just return the current list of employees

            //gets a list of workers who did work yesterday
            var whoWorked = _employeeRepository.GetAllEmployees().Where(employee => employee.LastShift == DateTimeOffset.UtcNow.AddDays(-1));

            //gets a list of workers who did not work
            var repo = _employeeRepository.GetAllEmployees().Where(employee => employee.LastShift != DateTimeOffset.UtcNow.AddDays(-1));

            //check for anyone who might not have worked yet
            var whosUp = repo.Where(x => x.ShiftCount < 2);
            
            //creates output array 
            var todaysEmployees = new Employee[numberOfShiftWorkers];

            // use a rules engine pattern for each employee to see if they can be assigned as well once you have randomly selected them
            for(int i = 0; i < numberOfShiftWorkers; i++)
            {
                var employeeIndex = random.Next(0, whosUp.Count());

                if (todaysEmployees.Contains(whosUp.ElementAt(employeeIndex)))
                {
                    i--;
                    continue;
                }
                
                var employee = whosUp.ElementAt(employeeIndex);

                if (employee.FirstShift is null)
                {
                    employee.FirstShift = DateTimeOffset.UtcNow.Date;
                }
                employee.LastShift = DateTimeOffset.UtcNow.Date;
                employee.ShiftCount++;
                _employeeRepository.UpdateEmployee(employee);
                todaysEmployees[i] = employee;
            }

            WorkerCycleCheck(whoWorked);
            return todaysEmployees;
        }

        // this will reset all of the employees cycle when they have reached their own 2 week mark, this method can be moved to the repository 
        private async Task WorkerCycleCheck(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee.FirstShift == DateTimeOffset.UtcNow.AddDays(-14).Date)
                {
                    employee.ShiftCount = 0;
                    employee.FirstShift = null;
                    employee.LastShift = null;
                    _employeeRepository.UpdateEmployee(employee);
                }
            }
        }
    }
}
        //for the api call it then endpoint will return a list of employees that have not worked the previous day
        //we can use a dateTime for the lastshift instead of a bool and then at the end of the day they