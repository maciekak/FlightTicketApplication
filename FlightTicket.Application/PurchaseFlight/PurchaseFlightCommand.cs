namespace FlightTicket.Application.PurchaseFlight
{
    public class PurchaseFlightCommand
    {
        public Guid TenantId { get; set; }
        public string FlightId { get; set; }
        public DateTime CustomerBirthday { get; set; }
    }
}
