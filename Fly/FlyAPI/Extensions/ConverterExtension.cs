
using Fly.Models;
using Fly;
using FlyAPI.Model;

namespace API.Extensions
{
    public static class ConverterExtensions
    {
        private static readonly string DELETED;

        static ConverterExtensions()
        {
            DELETED = "[DELETED]";
        }

        public static IEnumerable<FinalTicket> ConvertToFinalTicket(this Flight flight)
        {
            List<FinalTicket> result = new List<FinalTicket>();
            foreach (Booking booking in flight.BookingSet)
            {
                FinalTicket finalTicket = new FinalTicket();
                finalTicket.FirstName = booking.Passenger == null ? DELETED : booking.Passenger.Surname;
                finalTicket.LastName = booking.Passenger == null ? DELETED : booking.Passenger.FullName;
                finalTicket.FlightNbr = flight.FlightNo;
                finalTicket.Price = booking.SalePrice;
                result.Add(finalTicket);
            }
            return result;
        }
    }
}
