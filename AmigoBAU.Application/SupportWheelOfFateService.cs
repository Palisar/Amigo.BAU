//using System.Runtime.CompilerServices;
//using Amigo.BAU.Repository.EmployeeRepository;
//using Amigo.BAU.Repository.Models;

//namespace Amigo.BAU.Outside;

//public class SupportWheelOfFateService // make it a singleton service
//{
//    private readonly IEmployeeRepository _repository;

//    public SupportWheelOfFateService(IEmployeeRepository repository)
//    {
//        _repository = repository;
//    }
//    //this class can keep track of the time it was last called using DateTimeOffset.UTC.Now and check the current time vs the time it was last called,
//    //if it was last called the day before then it will run, if not return the current list of employees
//    public IEnumerable<Employee> WhoGoesToday(int numberOfShiftWorkers)
//    {
//        // if day has not yet passed the just return the current list of employees

//        //gets a list of workers who did work yesterday
//        var whoWorkedReset = _repository.GetAll().Where(x => x.WorkedShiftYesterday);

//        //gets a list of workers who did not work
//        var repo = _repository.GetAllEmployees().Where(x => !x.WorkedShiftYesterday);

//        //check for anyone who might not have worked yet
//        var whosUp = repo.Where(x => x.ShiftCount < 2);

//        //creates output array 
//        var todaysEmployees = new Employee[numberOfShiftWorkers];

//        // use a rules engine pattern for each employee to see if they can be assigned as well once you have randomly selected them
//        for (int i = 0; i < numberOfShiftWorkers; i++)
//        {
//            var employeeIndex = random.Next(0, repo.Count());

//            if (todaysEmployees.Contains(repo.ElementAt(employeeIndex)) || repo.ElementAt(employeeIndex).WorkedShiftYesterday)
//            {
//                i--;
//                continue;
//            }
//            var employee = repo.ElementAt(employeeIndex);

//            employee.WorkedShiftYesterday = true;
//            employee.ShiftCount++;
//            _repository.UpdateEmployee(employee);
//            todaysEmployees[i] = employee;
//        }

//        return todaysEmployees;
//    }
//}