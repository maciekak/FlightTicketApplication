using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Services;

namespace FlightTicket.Domain.DiscountRules
{
    public class AfricaThursdayDiscountRule : DiscountRule, IDiscountRule
    {
        private const string AfricaName = "africa";

        public override bool IsApplicable(DiscountContext context, Money currentPrice)
        {
            return base.IsApplicable(context, currentPrice)
                && context.Flight.Destination.ToLowerInvariant().Contains(AfricaName)
                && context.Flight.FlightDays.Contains(DayOfWeek.Thursday);
        }
    }
}
