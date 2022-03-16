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
                Name = "Paul Keating",
                ShiftCount = 0,
                WorkedShiftYesterday = false
            });
            employees.Add(new Employee
            {
                Id = 2,
                Name = "Ken Dunne",
                ShiftCount = 0,
                WorkedShiftYesterday = false,
            });
            employees.Add(new Employee
            {
                Id = 1,
                Name = "Paul Keating",
                ShiftCount = 0,
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
            employeeToUpdate.Name = employee.Name;
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
