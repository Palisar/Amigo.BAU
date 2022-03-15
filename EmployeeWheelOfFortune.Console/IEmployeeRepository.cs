namespace EmployeeWheelOfFortune.Console
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        bool DeleteEmployee(int id);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        bool UpdateEmployee(Employee employee);
    }
}