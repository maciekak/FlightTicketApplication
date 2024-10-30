using FlightTicket.Domain.Entities;

namespace FlightTicket.Domain.Repositories
{
    public interface ITenantRepository
    {
        Task<Tenant> GetTenantById(Guid tenantId);
    }
}
