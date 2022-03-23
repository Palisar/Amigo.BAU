using System.ComponentModel.DataAnnotations;

namespace Amigo.BAU.Repository.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
