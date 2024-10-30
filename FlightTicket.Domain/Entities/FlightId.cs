using System.Text.RegularExpressions;

namespace FlightTicket.Domain.Entities
{
    public record FlightId
    {
        public string Value { get; private set; }

        public FlightId(string value)
        {
            if (!IsValidFlightId(value))
                throw new ArgumentException("Invalid flight ID.");
            Value = value;
        }

        private bool IsValidFlightId(string flightId)
        {
            // Validate flight ID format: 3 letters, 5 digits, 3 letters
            return Regex.IsMatch(flightId, @"^[A-Z]{3}\d{5}[A-Z]{3}$");
        }
    }
}
