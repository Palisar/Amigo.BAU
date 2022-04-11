using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Persistance.QueryModels;

namespace Amigo.BAU.Application.Services
{
    public class SupportTeam : ISupportTeam
    {
        public IEnumerable<ShiftWorker> Staff { get; set; }
    }
}
