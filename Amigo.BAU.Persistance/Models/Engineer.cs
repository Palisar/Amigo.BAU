using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.BAU.Persistance.Models
{
    public class Engineer
    {
        public int EngineerId { get; set; }
        public DateTimeOffset FirstShift { get; set; }
        public DateTimeOffset LastShift  { get; set; }
        public int ShiftCount { get; set; }
        [Required]
        public int EmployeeId { get; init; }
    }
}
