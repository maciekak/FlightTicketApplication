using FlightTicket.Domain.Entities;

namespace FlightTicket.Domain.Services
{
    public interface ITenantPurchaseHandler
    {
        FlightPurchase HandlePurchase(Tenant tenant, Flight flight, DateTime purchaseDate, DateTime customerBirthday);
    }
}
