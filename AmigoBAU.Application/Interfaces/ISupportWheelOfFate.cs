using Amigo.BAU.Persistance.QueryModels;

namespace Amigo.BAU.Application.Services;

public interface ISupportWheelOfFate
{
    Task<IEnumerable<ShiftWorker>> WhoGoesToday();
}