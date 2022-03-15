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
            var repo = _employeeRepository.GetAllEmployees();
            var todaysEmployees = new Employee[numberOfShiftWorkers];

            // use a rules engine pattern for each employee to see if they can be assigned as well once you have randomly selected them
            for (int i = 0; i < numberOfShiftWorkers; i++)
            {
                var employeeIndex = random.Next(0, repo.Count());

                if (todaysEmployees.Contains(repo.ElementAt(employeeIndex)))
                {
                    i--;
                    continue;
                }

                var employee = repo.ElementAt(employeeIndex);
                employee.WorkedShiftYesterday = true;
                employee.ShiftCount++;

                todaysEmployees[i] = employee;
            }

            return todaysEmployees;
        }
    }
}
//for the api call it then endpoint will return a list of employees that have not worked the previous day
//we can use a dateTime for the lastshift instead of a bool and then at the end of the day they