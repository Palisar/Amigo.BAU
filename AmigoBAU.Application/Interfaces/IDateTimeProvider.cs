namespace Amigo.BAU.Application.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTimeOffset GetDay();
        bool DayChanged { get; }
    }
}
