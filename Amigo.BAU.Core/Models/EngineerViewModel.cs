using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.BAU.Repository.ViewModels
{
    public class EngineerViewModel
    {
        public string Name { get; set; }
        public int EngineerId { get; set; }
        public DateTimeOffset FirstShift { get; set; }
        public DateTimeOffset LastShift { get; set; }
        public int ShiftCount { get; set; }
    }
}
