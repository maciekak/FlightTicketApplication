using FlightTicket.Domain;
using FlightTicket.Domain.Repositories;
using FlightTicket.Infrastructure;

namespace FlightTicket.Application.AddNewFlight
{
    // Mediator Command Handler. It should be use mediator and its base classes, but in this demo I focused on Domain, they are not implemented
    public class AddNewFlightCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFlightRepository _flightRepository;

        public AddNewFlightCommandHandler(IUnitOfWork unitOfWork, IFlightRepository flightRepository)
        {
            _unitOfWork = unitOfWork;
            _flightRepository = flightRepository;
        }

        public async Task Handle(AddNewFlightCommand command)
        {
            await _flightRepository.AddFlight(new Flight(
                    new FlightId(command.FlightId),
                    command.Origin,
                    command.Destination,
                    command.FlightDays,
                    command.DepartureTime
                ))
                .ConfigureAwait(false);

            await _unitOfWork.Commit().ConfigureAwait(false);
        }
    }
}
