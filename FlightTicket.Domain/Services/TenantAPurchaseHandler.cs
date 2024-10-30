using FlightTicket.Domain.Entities;

namespace FlightTicket.Domain.Services
{
    public class TenantAPurchaseHandler : ITenantPurchaseHandler
    {
        private readonly IDiscountService _discountService;

        public TenantAPurchaseHandler(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public FlightPurchase HandlePurchase(Tenant tenant, Flight flight, DateTime purchaseDate, DateTime buyerBirthday)
        {
            var originalPrice = flight.GetPriceForDate(purchaseDate).Price;
            var context = new DiscountContext(flight, purchaseDate, buyerBirthday);

            var (finalPrice, appliedDiscounts) = _discountService.ApplyDiscounts(context, originalPrice);

            return new FlightPurchase(tenant, flight, finalPrice, appliedDiscounts);
        }
    }
}
