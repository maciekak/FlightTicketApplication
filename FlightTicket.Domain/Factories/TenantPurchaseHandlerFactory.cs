using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Services;

namespace FlightTicket.Domain.Factories
{
    public class TenantPurchaseHandlerFactory
    {
        private readonly DiscountService _discountService;

        public TenantPurchaseHandlerFactory(DiscountService discountService)
        {
            _discountService = discountService;
        }

        public ITenantPurchaseHandler CreateHandler(Tenant tenant)
        {
            return tenant.Type switch
            {
                TenantType.A => new TenantAPurchaseHandler(_discountService),
                TenantType.B => new TenantBPurchaseHandler(_discountService),
                _ => throw new ArgumentException("Invalid tenant type")
            };
        }
    }
}
