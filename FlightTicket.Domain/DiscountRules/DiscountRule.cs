using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Services;

namespace FlightTicket.Domain.DiscountRules
{
    public abstract class DiscountRule : IDiscountRule
    {
        protected decimal DiscountAmount = 5;
        protected decimal MinimalAmount = 20;

        public virtual Money ApplyDiscount(Money originalPrice)
        {
            return originalPrice - DiscountAmount;
        }

        public virtual bool IsApplicable(DiscountContext context, Money currentPrice)
        {
            return currentPrice.Amount - DiscountAmount >= MinimalAmount;
        }
    }
}
