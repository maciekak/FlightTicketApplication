using FlightTicket.Domain.Entities;

namespace FlightTicket.Domain.Services
{
    public class DiscountContext
    {
        public Flight Flight { get; }
        public DateTime PurchaseDate { get; }
        public DateTime BuyerBirthday { get; }

        public DiscountContext(Flight flight, DateTime purchaseDate, DateTime buyerBirthday)
        {
            Flight = flight;
            PurchaseDate = purchaseDate;
            BuyerBirthday = buyerBirthday;
        }
    }
}
