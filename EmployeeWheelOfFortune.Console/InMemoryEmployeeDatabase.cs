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
                FirstShift = DateTimeOffset.UtcNow.AddDays(-6).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-1).Date,
                ShiftCount = 2,

            });
            employees.Add(new Employee
            {
                Id = 2,
                Name = "Ken Dunne",
                FirstShift = DateTimeOffset.UtcNow.AddDays(-1).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-1).Date,
                ShiftCount = 1,

            });
            employees.Add(new Employee
            {
                Id = 3,
                Name = "Wham Bam",
                ShiftCount = 0,
            });
            employees.Add(new Employee
            {
                Id = 4,
                Name = "Sham Spam",
                ShiftCount = 0

            });
            employees.Add(new Employee
            {
                Id = 5,
                Name = "Dis Guy",
                ShiftCount = 3,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-9).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-2).Date,
            });
            employees.Add(new Employee
            {
                Id = 6,
                Name = "Ber Meuda",
                ShiftCount = 1,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-4).Date,
            });
            employees.Add(new Employee
            {
                Id = 7,
                Name = "John Marney",
                ShiftCount = 1,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-6).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-2).Date,
            });
            //employees.Add(new Employee
            //{
            //    Id = 4,
            //    Name = "Sham Spam",
            //    ShiftCount = 2,
            //    FirstShift = DateTimeOffset.UtcNow.AddDays(-6).Date,
            //    LastShift = DateTimeOffset.UtcNow.AddDays(-1).Date,
            //});
            //employees.Add(new Employee
            //{
            //    Id = 4,
            //    Name = "Sham Spam",
            //    ShiftCount = 2,
            //    FirstShift = DateTimeOffset.UtcNow.AddDays(-6).Date,
            //    LastShift = DateTimeOffset.UtcNow.AddDays(-1).Date,
            //});
            //employees.Add(new Employee
            //{
            //    Id = 4,
            //    Name = "Sham Spam",
            //    ShiftCount = 2,
            //    FirstShift = DateTimeOffset.UtcNow.AddDays(-6).Date,
            //    LastShift = DateTimeOffset.UtcNow.AddDays(-1).Date,
            //});
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

        public async Task UpdateEmployee(Employee employee)
        {
            if (employee is not null)
            {
                var employeeToUpdate = GetEmployeeById(employee.Id);
                employeeToUpdate.ShiftCount = employee.ShiftCount;
                employeeToUpdate.FirstShift = employee.FirstShift;
                employeeToUpdate.LastShift = employee.LastShift;
            }
        }

        public void DeleteEmployee(int id)
        {
            var employeeToDelete = GetEmployeeById(id);
            employees.Remove(employeeToDelete);
        }
    }
}
