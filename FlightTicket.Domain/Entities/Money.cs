namespace FlightTicket.Domain.Entities
{
    public record Money(decimal Amount, string Currency)
    {
        public static Money operator -(Money left, Money right)
        {
            if (left.Currency != right.Currency) throw new ArgumentException("Not the same currencies, cannot be subtracted.");

            return new Money(left.Amount - right.Amount, left.Currency);
        }
        public static Money operator -(Money left, decimal rightAmount)
        {
            return new Money(left.Amount - rightAmount, left.Currency);
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }
}
