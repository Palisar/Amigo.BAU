using Amigo.BAU.Persistance.QueryModels;

namespace Amigo.BAU.Application.Services;

public interface ISupportWheelOfFateService
{
    IEnumerable<ShiftWorker> WhoGoesToday(int numberOfShiftWorkers);
}