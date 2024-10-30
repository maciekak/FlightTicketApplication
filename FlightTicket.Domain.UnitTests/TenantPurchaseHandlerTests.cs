using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Factories;
using FlightTicket.Domain.Services;

namespace FlightTicket.Domain.UnitTests
{
    [TestFixture]
    public class TenantPurchaseHandlerTests
    {
        private DiscountService _discountService;

        [SetUp]
        public void Setup()
        {
            var discountFactory = new DiscountFactory();
            _discountService = new DiscountService(discountFactory);
        }

        [Test]
        public void TenantAPurchaseHandler_ShouldRecordDiscounts()
        {
            // Arrange
            var handler = new TenantAPurchaseHandler(_discountService);
            var tenant = new Tenant(Guid.NewGuid(), TenantType.A);
            var flight = new Flight(new FlightId("KLM12345ABC"), "London, Europe", "Khartoum, Africa", new List<DayOfWeek> { DayOfWeek.Thursday }, TimeSpan.FromHours(10));
            flight.AddPrice(new FlightPrice(new DateTime(2024, 10, 29), new DateTime(2024, 10, 31), new Money(30, "EUR")));

            // Act
            var purchase = handler.HandlePurchase(tenant, flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 30)); // both criteria met

            // Assert
            Assert.AreEqual(20, purchase.FinalPrice.Amount);
            Assert.IsNotNull(purchase.AppliedDiscounts);
            Assert.Contains("BirthdayDiscountRule", purchase.AppliedDiscounts);
            Assert.Contains("AfricaThursdayDiscountRule", purchase.AppliedDiscounts);
        }

        [Test]
        public void TenantBPurchaseHandler_ShouldNotRecordDiscounts()
        {
            // Arrange
            var handler = new TenantBPurchaseHandler(_discountService);
            var tenant = new Tenant(Guid.NewGuid(), TenantType.B);
            var flight = new Flight(new FlightId("KLM12345ABC"), "London, Europe", "Khartoum, Africa", new List<DayOfWeek> { DayOfWeek.Thursday }, TimeSpan.FromHours(10));
            flight.AddPrice(new FlightPrice(new DateTime(2024, 10, 29), new DateTime(2024, 10, 31), new Money(30, "EUR")));

            // Act
            var purchase = handler.HandlePurchase(tenant, flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 30));

            // Assert
            Assert.AreEqual(20, purchase.FinalPrice.Amount);
            Assert.IsNull(purchase.AppliedDiscounts); // Tenant B should not record applied discounts
        }
    }
}