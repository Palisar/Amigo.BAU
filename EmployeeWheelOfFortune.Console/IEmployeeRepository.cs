namespace EmployeeWheelOfFortune.Console
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Task UpdateEmployee(Employee employee);
    }
}