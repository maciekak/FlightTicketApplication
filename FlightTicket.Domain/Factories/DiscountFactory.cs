using FlightTicket.Domain.DiscountRules;

namespace FlightTicket.Domain.Factories
{
    public class DiscountFactory
    {
        public List<IDiscountRule> CreateDiscountRules()
        {
            return new List<IDiscountRule>
        {
            new BirthdayDiscountRule(),
            new AfricaThursdayDiscountRule()
            // Additional discount rules can be registered here
        };
        }
    }
}
