using FlightTicket.Domain.Repositories;
using FlightTicket.Domain.Services;
using FlightTicket.Infrastructure;

namespace FlightTicket.Application.PurchaseFlight
{
    // Mediator Command Handler. It should be use mediator and its base classes, but in this demo I focused on Domain, they are not implemented
    public class PurchaseFlightCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFlightBookingService _flightBookingService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ITenantRepository _tenantRepository;
        private readonly IFlightRepository _flightRepository;

        public PurchaseFlightCommandHandler(
            IUnitOfWork unitOfWork,
            IFlightBookingService flightBookingService,
            IDateTimeProvider dateTimeProvider,
            ITenantRepository tenantRepository,
            IFlightRepository flightRepository)
        {
            _unitOfWork = unitOfWork;
            _flightBookingService = flightBookingService;
            _dateTimeProvider = dateTimeProvider;
            _tenantRepository = tenantRepository;
            _flightRepository = flightRepository;
        }

        public async Task Handle(PurchaseFlightCommand command)
        {
            var purchaseDate = _dateTimeProvider.CurrentDate;
            var flight = await _flightRepository.GetFlightById(new FlightId(command.FlightId));
            var tenant = await _tenantRepository.GetTenantById(command.TenantId);

            _flightBookingService.BookFlight(tenant, flight, purchaseDate, command.CustomerBirthday);

            await _unitOfWork.Commit();
        }
    }
}
