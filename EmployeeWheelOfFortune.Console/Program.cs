using EmployeeWheelOfFortune.Console;

IEmployeeRepository employeeRepository = new InMemoryEmployeeDatabase();
WheelOfFortune wheelOfFortune = new(employeeRepository);
var todaysEmployees = wheelOfFortune.WhoGoesToday(2);
foreach (var employee in todaysEmployees)
{
    Console.WriteLine($"{employee.Name} will work today.");
}