using System.ComponentModel.DataAnnotations;

namespace Amigo.BAU.Application.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ShiftCount { get; set; }
        public bool WorkedShiftYesterday { get; set; }
    }
}
