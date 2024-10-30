using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Factories;
using FlightTicket.Domain.Services;

namespace FlightTicket.Domain.UnitTests
{
    [TestFixture]
    public class FlightBookingServiceTests
    {
        private FlightBookingService _flightBookingService;
        private TenantPurchaseHandlerFactory _handlerFactory;
        private DiscountService _discountService;

        [SetUp]
        public void Setup()
        {
            var discountFactory = new DiscountFactory();
            _discountService = new DiscountService(discountFactory);
            _handlerFactory = new TenantPurchaseHandlerFactory(_discountService);
            _flightBookingService = new FlightBookingService(_handlerFactory);
        }

        [Test]
        public void BookFlight_ShouldDelegateToTenantAHandler()
        {
            // Arrange
            var tenant = new Tenant(Guid.NewGuid(), TenantType.A);
            var flight = new Flight(new FlightId("KLM12345ABC"), "London, Europe", "Khartoum, Africa", new List<DayOfWeek> { DayOfWeek.Thursday }, TimeSpan.FromHours(10));
            flight.AddPrice(new FlightPrice(new DateTime(2024, 10, 29), new DateTime(2024, 10, 31), new Money(30, "EUR")));

            // Act
            var purchase = _flightBookingService.BookFlight(tenant, flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 30));

            // Assert
            Assert.AreEqual(20, purchase.FinalPrice.Amount);
            Assert.IsNotNull(purchase.AppliedDiscounts);
        }

        [Test]
        public void BookFlight_ShouldDelegateToTenantBHandler()
        {
            // Arrange
            var tenant = new Tenant(Guid.NewGuid(), TenantType.B);
            var flight = new Flight(new FlightId("KLM12345ABC"), "London, Europe", "Khartoum, Africa", new List<DayOfWeek> { DayOfWeek.Thursday }, TimeSpan.FromHours(10));
            flight.AddPrice(new FlightPrice(new DateTime(2024, 10, 29), new DateTime(2024, 10, 31), new Money(30, "EUR")));

            // Act
            var purchase = _flightBookingService.BookFlight(tenant, flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 30));

            // Assert
            Assert.AreEqual(20, purchase.FinalPrice.Amount);
            Assert.IsNull(purchase.AppliedDiscounts); // Discounts should not be recorded for Tenant B
        }
    }
}