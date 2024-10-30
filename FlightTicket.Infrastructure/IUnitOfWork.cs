namespace FlightTicket.Infrastructure
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
