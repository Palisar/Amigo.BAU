using System.Security.Cryptography.X509Certificates;

namespace EmployeeWheelOfFortune.Console
{
    public class WheelOfFortune
    {
        private readonly IEmployeeRepository _employeeRepository;
        private static Random random = new();

        public WheelOfFortune(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> WhoGoesToday(int numberOfShiftWorkers)
        {
            // if day has not yet passed the just return the current list of employees
            
            //gets a list of workers who did work yesterday
            var whoWorkedReset = _employeeRepository.GetAllEmployees().Where(x => x.WorkedShiftYesterday);
            
            //gets a list of workers who did not work
            var repo = _employeeRepository.GetAllEmployees().Where(x => !x.WorkedShiftYesterday);

            //check for anyone who might not have worked yet
            var whosUp = repo.Where(x => x.ShiftCount < 2);

            //creates output array 
            var todaysEmployees = new Employee[numberOfShiftWorkers];

            // use a rules engine pattern for each employee to see if they can be assigned as well once you have randomly selected them
            for(int i = 0; i < numberOfShiftWorkers; i++)
            {
                var employeeIndex = random.Next(0, repo.Count());

                if (todaysEmployees.Contains(repo.ElementAt(employeeIndex)) || repo.ElementAt(employeeIndex).WorkedShiftYesterday)
                {
                    i--;
                    continue;
                }
                var employee = repo.ElementAt(employeeIndex);
                
                employee.WorkedShiftYesterday = true;
                employee.ShiftCount++;
                _employeeRepository.UpdateEmployee(employee);
                todaysEmployees[i] = employee;
            }

            return todaysEmployees;
        }
    }
}
        //for the api call it then endpoint will return a list of employees that have not worked the previous day
        //we can use a dateTime for the lastshift instead of a bool and then at the end of the day they