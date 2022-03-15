using EmployeeWheelOfFortune.Console;

IEmployeeRepository employeeRepository = new InMemoryEmployeeDatabase();
WheelOfFortune wheelOfFortune = new WheelOfFortune(employeeRepository);
var todaysEmployees = wheelOfFortune.WhoGoesToday(2);
foreach (var employee in todaysEmployees)
{

}