using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.BAU.Application.Interfaces
{
    public interface IDateTimeProvider
    {
        public DateTimeOffset GetDay();
    }
}
