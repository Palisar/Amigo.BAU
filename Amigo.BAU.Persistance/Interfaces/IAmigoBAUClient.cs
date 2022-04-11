using Amigo.BAU.Persistance.QueryModels;
using Refit;

namespace Amigo.BAU.Persistance.Interfaces
{
    public interface IAmigoBAUClient
    {
        [Get("/api/WheelOfFate")]
        Task<ApiResponse<IEnumerable<ShiftWorkerResponse>>> WheelOfFate();
    }
}
