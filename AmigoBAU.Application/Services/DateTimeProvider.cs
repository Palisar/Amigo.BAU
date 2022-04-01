using Amigo.BAU.Application.Interfaces;

namespace Amigo.BAU.Application.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset TodaysDate { get; private set; }
        public DateTimeProvider(DateTimeOffset date)
        {
            TodaysDate = date.UtcDateTime.Date;
        }
        private void NextDay()
        {
            TodaysDate = DateTimeOffset.UtcNow.Date;
        }
        public DateTimeOffset GetDay()
        {
            if (DateTimeOffset.UtcNow.Date > TodaysDate.Date)
                NextDay();

            return TodaysDate.Date;
        }
    }
}
