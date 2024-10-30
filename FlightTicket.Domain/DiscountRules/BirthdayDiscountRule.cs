using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Services;

namespace FlightTicket.Domain.DiscountRules
{
    public class BirthdayDiscountRule : DiscountRule, IDiscountRule
    {
        public override bool IsApplicable(DiscountContext context, Money currentPrice)
        {
            return base.IsApplicable(context, currentPrice)
                && context.PurchaseDate.Date == context.BuyerBirthday.Date;
        }
    }
}
