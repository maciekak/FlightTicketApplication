using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Factories;

namespace FlightTicket.Domain.Services
{
    public class FlightBookingService : IFlightBookingService
    {
        private readonly TenantPurchaseHandlerFactory _handlerFactory;

        public FlightBookingService(TenantPurchaseHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        public FlightPurchase BookFlight(Tenant tenant, Flight flight, DateTime purchaseDate, DateTime buyerBirthday)
        {
            var handler = _handlerFactory.CreateHandler(tenant);
            return handler.HandlePurchase(tenant, flight, purchaseDate, buyerBirthday);
        }
    }
}
