using FlightTicket.Domain.Entities;

namespace FlightTicket.Domain.Services
{
    public interface IDiscountService
    {
        (Money finalPrice, List<string> appliedDiscounts) ApplyDiscounts(DiscountContext context, Money originalPrice);
    }
}