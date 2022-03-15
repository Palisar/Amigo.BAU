using System.ComponentModel.DataAnnotations;

namespace EmployeeWheelOfFortune.Console
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateStarted { get; set; }
        public int ShiftCount { get; set; }
        public bool WorkedShiftYesterday { get; set; } = false;

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
