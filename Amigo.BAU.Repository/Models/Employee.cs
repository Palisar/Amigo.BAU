using System.ComponentModel.DataAnnotations;

namespace Amigo.BAU.Repository.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
