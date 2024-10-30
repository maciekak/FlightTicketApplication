using FlightTicket.Domain.Entities;

namespace FlightTicket.Application.AddNewFlight
{
    public class AddNewFlightCommand
    {
        public string FlightId { get; private set; }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public List<DayOfWeek> FlightDays { get; private set; }
        public TimeSpan DepartureTime { get; private set; }
        public List<FlightPrice> Prices { get; private set; }
    }
}
