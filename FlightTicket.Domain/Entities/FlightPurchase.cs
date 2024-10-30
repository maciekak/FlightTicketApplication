namespace FlightTicket.Domain.Entities
{
    public class FlightPurchase
    {
        public Tenant Tenant { get; private set; }
        public Flight Flight { get; private set; }
        public Money FinalPrice { get; private set; }
        public List<string> AppliedDiscounts { get; private set; }

        public FlightPurchase(Tenant tenant, Flight flight, Money finalPrice, List<string> appliedDiscounts)
        {
            Tenant = tenant;
            Flight = flight;
            FinalPrice = finalPrice;
            AppliedDiscounts = appliedDiscounts;
        }
    }
}
