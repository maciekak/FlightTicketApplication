using FlightTicket.Domain.DiscountRules;
using FlightTicket.Domain.Entities;
using FlightTicket.Domain.Services;

namespace FlightTicket.Domain.UnitTests
{
    [TestFixture]
    public class DiscountRuleTests
    {
        [Test]
        public void BirthdayDiscountRule_ShouldApplyDiscount_OnBirthday()
        {
            // Arrange
            var rule = new BirthdayDiscountRule();
            var flight = new Flight(new FlightId("KLM12345ABC"), "Paris, Europe", "London, Europe", new List<DayOfWeek> { DayOfWeek.Monday }, TimeSpan.FromHours(10));
            var context = new DiscountContext(flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 30)); // purchase date is buyer's birthday
            var originalPrice = new Money(30, "EUR");

            // Act
            var newPrice = rule.ApplyDiscount(originalPrice);

            // Assert
            Assert.AreEqual(25, newPrice.Amount);
        }

        [Test]
        public void BirthdayDiscountRule_ShouldNotApplyDiscount_WhenNotBirthday()
        {
            // Arrange
            var rule = new BirthdayDiscountRule();
            var flight = new Flight(new FlightId("KLM12345ABC"), "Paris, Europe", "London, Europe", new List<DayOfWeek> { DayOfWeek.Monday }, TimeSpan.FromHours(10));
            var context = new DiscountContext(flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 29));
            var originalPrice = new Money(30, "EUR");

            // Act
            var applicable = rule.IsApplicable(context, originalPrice);

            // Assert
            Assert.IsFalse(applicable);
        }

        [Test]
        public void AfricaThursdayDiscountRule_ShouldApplyDiscount_WhenFlightToAfricaOnThursday()
        {
            // Arrange
            var rule = new AfricaThursdayDiscountRule();
            var flight = new Flight(new FlightId("KLM12345ABC"), "London, Europe", "Khartoum, Africa", new List<DayOfWeek> { DayOfWeek.Thursday }, TimeSpan.FromHours(10));
            var context = new DiscountContext(flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 30));
            var originalPrice = new Money(30, "EUR");

            // Act, Assert
            var applicable = rule.IsApplicable(context, originalPrice);
            Assert.IsTrue(applicable);

            var newPrice = rule.ApplyDiscount(originalPrice);
            Assert.AreEqual(25, newPrice.Amount);
        }

        [Test]
        public void AfricaThursdayDiscountRule_ShouldNotApplyDiscount_WhenNotThursdayOrNotToAfrica()
        {
            // Arrange
            var rule = new AfricaThursdayDiscountRule();
            var flight = new Flight(new FlightId("KLM12345ABC"), "London, Europe", "New Delhi, Asia", new List<DayOfWeek> { DayOfWeek.Friday }, TimeSpan.FromHours(10));
            var context = new DiscountContext(flight, new DateTime(2024, 10, 30), new DateTime(2024, 10, 30));
            var originalPrice = new Money(30, "EUR");

            // Act
            var applicable = rule.IsApplicable(context, originalPrice);

            // Assert
            Assert.IsFalse(applicable);
        }
    }
}