using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amigo.BAU.Persistance.QueryModels;

namespace Amigo.BAU.Application.Interfaces
{
    public interface ISupportTeam
    {
        IEnumerable<ShiftWorker>? Staff { get; set; }
    }
}
