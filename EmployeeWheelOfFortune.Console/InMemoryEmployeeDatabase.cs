namespace EmployeeWheelOfFortune.Console
{
    public class InMemoryEmployeeDatabase : IEmployeeRepository
    {
        public List<Employee> employees = new();
        public InMemoryEmployeeDatabase()
        {
            employees.Add(new Employee
            {
                Id = 1,
                FirstName = "Paul",
                LastName = "Keating",
                EmployeeId = 1234,
                DateStarted = new DateTime(2022, 3, 15),
                ShiftCount = 0,
                WorkedShiftYesterday = false
            });
            employees.Add(new Employee
            {
                Id = 2,
                FirstName = "Ken",
                LastName = "Dunne",
                EmployeeId = 2234,
                DateStarted = new DateTime(2021, 1, 10),
                ShiftCount = 0,
                WorkedShiftYesterday = false,
            });
            employees.Add(new Employee
            {
                Id = 3,
                FirstName = "Jane",
                LastName = "Doe",
                EmployeeId = 3234,
                DateStarted = new DateTime(2020, 12, 29),
                ShiftCount = 1,
                WorkedShiftYesterday = true,
            });
            employees.Add(new Employee
            {
                Id = 4,
                FirstName = "Chris",
                LastName = "Green",
                EmployeeId = 6234,
                DateStarted = new DateTime(2021, 12, 2),
                ShiftCount = 2,
                WorkedShiftYesterday = false
            });
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
        }

        public bool UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = GetEmployeeById(employee.Id);
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.EmployeeId = employee.EmployeeId;
            employeeToUpdate.DateStarted = employee.DateStarted;
            employeeToUpdate.ShiftCount = employee.ShiftCount;
            employeeToUpdate.WorkedShiftYesterday = employee.WorkedShiftYesterday;
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            var employeeToDelete = GetEmployeeById(id);
            employees.Remove(employeeToDelete);
            return true;
        }

    }
}
