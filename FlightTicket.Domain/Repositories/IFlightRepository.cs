using FlightTicket.Domain.Entities;

namespace FlightTicket.Domain.Repositories
{
    public interface IFlightRepository
    {
        Task AddFlight(Flight flight);
        Task<Flight> GetFlightById(FlightId flightId);
    }
}
