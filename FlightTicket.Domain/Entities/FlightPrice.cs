namespace FlightTicket.Domain.Entities
{
    public class FlightPrice
    {
        // When nulls then means it is unbounded
        public DateTime? FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public Money Price { get; private set; }

        public FlightPrice(DateTime? fromDate, DateTime? toDate, Money price)
        {
            FromDate = fromDate;
            ToDate = toDate;
            Price = price;
        }

        public bool IsApplicableOn(DateTime date)
        {
            return (!FromDate.HasValue || FromDate.Value <= date)
                && (!ToDate.HasValue || ToDate.Value >= date);
        }
    }
}
