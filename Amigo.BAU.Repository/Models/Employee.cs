using System.ComponentModel.DataAnnotations;

namespace Amigo.BAU.Repository.Models
{
    public class Employee
    {
        
        public Guid EmployeeId { get; init; }
        public string Name { get; set; }
        public string Email { get; set; }
        
    }
}
