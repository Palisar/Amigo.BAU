using System.ComponentModel.DataAnnotations;

namespace EmployeeWheelOfFortune.Console
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ShiftCount { get; set; }
        public bool WorkedShiftYesterday { get; set; }

    }
}
