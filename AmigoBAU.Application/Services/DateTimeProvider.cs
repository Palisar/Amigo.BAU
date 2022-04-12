using Amigo.BAU.Application.Interfaces;

namespace Amigo.BAU.Application.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset TodaysDate { get; private set; }
        public bool DayChanged { get; private set; }
        public DateTimeProvider()
        {// instanciate the class with the previous date so it will run the first time it is called
            TodaysDate = DateTimeOffset.UtcNow.AddDays(-1).Date;
        }
        private void NextDay()
        {
            TodaysDate = DateTimeOffset.UtcNow.Date;
        }
        public DateTimeOffset GetDay()
        {
            if (DateTimeOffset.UtcNow.Date > TodaysDate.Date)
            {
                NextDay();
                DayChanged = true;
            }
            else
            {
                DayChanged = false;
            }

            return TodaysDate.Date;
        }
    }
}
