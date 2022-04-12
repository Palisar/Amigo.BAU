using Amigo.BAU.Persistance.QueryModels;

namespace Amigo.BAU.Application.Interfaces
{
    public interface ISupportTeam
    {
        public bool IsConfirmedToday { get; }
        IEnumerable<ShiftWorker>? Staff { get; set; }
        public void ConfirmTodaysStaff();
        public void ResetStaff();
    }
}
