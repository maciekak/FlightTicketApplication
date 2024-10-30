using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Factories;
using FlightTicket.Domain.Services;

namespace FlightTicket.Domain.UnitTests
{
    [TestFixture]
    public class DiscountServiceTests
    {
        private DiscountService _discountService;

        [SetUp]
        public void Setup()
        {
            var discountFactory = new DiscountFactory();
            _discountService = new DiscountService(discountFactory);
        }

        [Test]
        public void ApplyDiscounts_ShouldApplyMultipleDiscounts_Correctly()
        {
            // Arrange
            var flight = new Flight(new FlightId("KLM12345ABC"), "London, Europe", "Khartoum, Africa", new List<DayOfWeek> { DayOfWeek.Thursday }, TimeSpan.FromHours(10));
            var context = new DiscountContext(flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 30)); // both criteria met
            var originalPrice = new Money(30, "EUR");

            // Act
            var (finalPrice, appliedDiscounts) = _discountService.ApplyDiscounts(context, originalPrice);

            // Assert
            Assert.AreEqual(20, finalPrice.Amount);
            Assert.Contains("BirthdayDiscountRule", appliedDiscounts);
            Assert.Contains("AfricaThursdayDiscountRule", appliedDiscounts);
        }

        [Test]
        public void ApplyDiscounts_ShouldNotGoBelowMinimumPrice()
        {
            // Arrange
            var flight = new Flight(new FlightId("KLM12345ABC"), "London, Europe", "Khartoum, Africa", new List<DayOfWeek> { DayOfWeek.Thursday }, TimeSpan.FromHours(10));
            var context = new DiscountContext(flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 30));
            var originalPrice = new Money(21, "EUR");

            // Act
            var (finalPrice, _) = _discountService.ApplyDiscounts(context, originalPrice);

            // Assert
            Assert.AreEqual(21, finalPrice.Amount);
        }
    }
}