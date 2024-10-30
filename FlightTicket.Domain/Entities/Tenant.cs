namespace FlightTicket.Domain.Entities
{
    public class Tenant
    {
        public Guid Id { get; }

        public TenantType Type { get; }

        public Tenant(Guid id, TenantType type)
        {
            Id = id;
            Type = type;
        }
    }
}
