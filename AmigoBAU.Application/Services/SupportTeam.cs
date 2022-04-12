using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Persistance.QueryModels;

namespace Amigo.BAU.Application.Services
{
    public class SupportTeam : ISupportTeam
    {
        private readonly IDateTimeProvider _date;

        public bool IsConfirmedToday { get; private set; }
        public SupportTeam(IDateTimeProvider _date)
        {
            this._date = _date;
            this.IsConfirmedToday = false;
        }
        public IEnumerable<ShiftWorker>? Staff { get; set; }

        public void ConfirmTodaysStaff()
        {
            this.IsConfirmedToday = true;
            UpdateWhoWorked();
        }

        public void ResetStaff()
        {
            Staff = null;
            this.IsConfirmedToday = false;
        }

        private void UpdateWhoWorked()
        {
            foreach (ShiftWorker employee in Staff)
            {
                employee.ShiftCount = employee.ShiftCount == null ? 1 : employee.ShiftCount + 1;

                employee.FirstShift = employee.FirstShift == null ? _date.GetDay() : employee.FirstShift;

                employee.LastShift = _date.GetDay();
            }
        }
    }
}
