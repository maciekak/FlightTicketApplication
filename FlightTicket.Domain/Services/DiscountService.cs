using FlightTicket.Domain.DiscountRules;
using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Factories;

namespace FlightTicket.Domain.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly List<IDiscountRule> _rules;

        public DiscountService(DiscountFactory discountFactory)
        {
            _rules = discountFactory.CreateDiscountRules();
        }

        public (Money finalPrice, List<string> appliedDiscounts) ApplyDiscounts(DiscountContext context, Money originalPrice)
        {
            var appliedDiscounts = new List<string>();
            Money discountedPrice = originalPrice;

            foreach (var rule in _rules)
            {
                if (rule.IsApplicable(context, discountedPrice))
                {
                    discountedPrice = rule.ApplyDiscount(discountedPrice);
                    appliedDiscounts.Add(rule.GetType().Name);
                }

                if (discountedPrice.Amount <= 20)
                    break;
            }

            return (discountedPrice, appliedDiscounts);
        }
    }
}
