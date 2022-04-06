namespace Amigo.BAU.Application.Interfaces
{
    public interface IDateTimeProvider
    {
        public DateTimeOffset GetDay();
        bool DayChanged { get; }
    }
}
