using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Services;

namespace FlightTicket.Domain.DiscountRules
{
    public interface IDiscountRule
    {
        bool IsApplicable(DiscountContext context, Money currentPrice);
        Money ApplyDiscount(Money originalPrice);
    }
}
