using API.Models;
using FlyAlex.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            List<FinalTicket> tickets = new List<FinalTicket>();
            foreach(Booking booking in flight.Bookings)
            {
                FinalTicket finalTicket = new FinalTicket();
                finalTicket.FirstName = booking.Passenger == null ? DELETED : booking.Passenger.Surname;
                finalTicket.LastName = booking.Passenger == null ? DELETED : booking.Passenger.FullName;
                finalTicket.FlightNbr = flight.FlightNo;
                finalTicket.Price = flight.Price;
                tickets.Add(finalTicket);
            }
            return tickets;
        }

        public static FlightM ConvertTolFlightM(this Flight flight)
        {
            FlightM result = new FlightM();
            result.FlightId = flight.FlightId;
            result.Date = flight.Date;
            result.Depart = flight.Depart;
            result.Price = flight.Price;
            result.Occupation = flight.Occupation;
            result.Destination = flight.Destination;
            result.FlightNo = flight.FlightNo;
            result.FreeSeats = flight.FreeSeat;
            result.NbrSeats = result.NbrSeats;
            result.Price = result.Price;
            return result;
        }
    }
}
