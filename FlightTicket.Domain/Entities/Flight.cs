namespace FlightTicket.Domain.Entities
{
    public class Flight
    {
        public FlightId FlightId { get; private set; }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public List<DayOfWeek> FlightDays { get; private set; }
        public TimeSpan DepartureTime { get; private set; }
        public List<FlightPrice> Prices { get; private set; }

        public Flight(FlightId flightId, string origin, string destination, List<DayOfWeek> flightDays, TimeSpan departureTime)
        {
            FlightId = flightId;
            Origin = origin;
            Destination = destination;
            FlightDays = flightDays;
            DepartureTime = departureTime;
            Prices = new List<FlightPrice>();
        }
        public void AddPrice(FlightPrice price)
        {
            Prices.Add(price);
        }

        public FlightPrice GetPriceForDate(DateTime date)
        {
            return Prices.FirstOrDefault(p => p.IsApplicableOn(date)) ?? throw new ArgumentNullException("Price doesn't exist for current purchase date");
        }
    }
}
