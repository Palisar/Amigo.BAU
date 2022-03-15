using System.ComponentModel.DataAnnotations;

namespace Amigo.BAU.Application.Models
{
    public class EmployeeModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public DateTime DateStarted { get; set; }
        public int ShiftCount { get; set; }
        public bool WorkedShiftYesterday { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
