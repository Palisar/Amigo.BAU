using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.BAU.Repository.Models
{
    class Engineer
    {
        [Key]
        [Required]
        public Guid EngineerId { get; init; }
        public DateTimeOffset FirstShift { get; set; }
        public DateTimeOffset LastShift  { get; set; }
        public int ShiftCount { get; set; }
        [Required]
        public int EmployeeId { get; init; }
    }
}
