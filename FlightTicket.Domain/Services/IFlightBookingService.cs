using FlightTicket.Domain.Entities;

namespace FlightTicket.Domain.Services
{
    public interface IFlightBookingService
    {
        FlightPurchase BookFlight(Tenant tenant, Flight flight, DateTime purchaseDate, DateTime buyerBirthday);
    }
}