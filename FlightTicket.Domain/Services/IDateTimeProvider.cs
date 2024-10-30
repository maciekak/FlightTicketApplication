namespace FlightTicket.Domain.Services
{
    public interface IDateTimeProvider
    {
        DateTime CurrentDate { get; }
    }
}
