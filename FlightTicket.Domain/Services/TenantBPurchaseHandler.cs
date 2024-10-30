using FlightTicket.Domain.Entities;

namespace FlightTicket.Domain.Services
{
    public class TenantBPurchaseHandler : ITenantPurchaseHandler
    {
        private readonly IDiscountService _discountService;

        public TenantBPurchaseHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public FlightPurchase HandlePurchase(Tenant tenant, Flight flight, DateTime purchaseDate, DateTime buyerBirthday)
        {
            var originalPrice = flight.GetPriceForDate(purchaseDate).Price;
            var context = new DiscountContext(flight, purchaseDate, buyerBirthday);

            var (finalPrice, _) = _discountService.ApplyDiscounts(context, originalPrice);

            return new FlightPurchase(tenant, flight, finalPrice, null); // Does not record discounts for Tenant B
        }
    }
}
