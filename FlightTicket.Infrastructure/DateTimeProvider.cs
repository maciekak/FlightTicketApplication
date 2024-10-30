using FlightTicket.Domain.Services;

namespace FlightTicket.Domain
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime CurrentDate => DateTime.UtcNow;
    }
}
