using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fly;
using Fly.Models;

namespace FlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly Context _context;

        public FlightsController(Context context)
        {
            _context = context;
        }
     
        // a. Return all flights 
        [HttpGet("GetAvailableFlights")]
        public async Task<ActionResult<List<Flight>>> GetAvailableFlights()
        {
            var flightsAvailableList = await _context.FlightSet.Where(f => f.occupation > 0 && f.Date > DateTime.Now).ToListAsync();
            return flightsAvailableList;
        }

        // b. Return the price of a flight
        [HttpGet("GetPriceFromFlight/{flightId}")]
        public async Task<ActionResult<double>> GetPriceFromFlight(int flightId)
        {
            var flight = await _context.FlightSet.FindAsync(flightId);
            if (flight == null)
            {
                return NotFound();
            }
            return calculatePrice(flight);
        }

        // b. Return the sale price of a flight
        private double calculatePrice(Flight flight)
        {
            double flightPrice = flight.Price;
            double CurrentlyPrice = flightPrice;
            int freeSeat = flight.FreeSeat;
            int NbrSeat = flight.NbrSeat;
            int OccupatedSeats = NbrSeat - freeSeat;
            double ratio = (double)OccupatedSeats / NbrSeat;
            DateTime today = DateTime.Now;
            double months = (flight.Date - DateTime.Now).TotalDays;

            if (ratio > 0.8)
            {
                CurrentlyPrice = flightPrice * 1.5;
            }
            if (ratio < 0.2 && months < 60)
            {
                CurrentlyPrice = flightPrice * 0.8;
            }
            if (ratio < 0.5 && months < 30)
            {
                CurrentlyPrice = flightPrice * 0.7;
            }
            return CurrentlyPrice;
        }

       
        // C. Books a ticket on a flight
       
        [HttpPut("BookFlight/{passengerId}&{flightId}")]
        public async Task<IActionResult> BuyFlight(int passengerId, int flightId)
        {
            var p = await _context.PassengerSet.FindAsync(passengerId);
            var f = await _context.FlightSet.FindAsync(flightId);
            if (p == null || f == null )
            {
                return NotFound();
            }
            Booking booking = new Booking();
            booking.PassengerID = p.PersonID;
            booking.Passenger = p;
            booking.Flight = f;
            booking.SalePrice = calculatePrice(f);
            _context.BookingSet.Add(booking);
            f.FreeSeat -= 1;
            f.occupation = (Convert.ToDouble(f.NbrSeat) - Convert.ToDouble(f.FreeSeat)) / Convert.ToDouble(f.NbrSeat);
            _context.Entry(f).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // d. Return the total sale price of all tickets sold for a flight
        [HttpGet("GetTotalSalePriceOfFlight/{flightId}")]
        public async Task<ActionResult<double>> GetTotalSalePriceFlight(int flightId)
        {
            var sales = await _context.BookingSet.Where(s => s.Flight.FlightId == flightId).ToListAsync();
            double total = sales.Sum(s => s.SalePrice);
            return total;
        }

        //e. Average sale price from all tickets sold for a destination
        [HttpGet("AverageTicketPrice/{destination}")]
        public async Task<ActionResult<double>> GetAverageSalePriceForDestination(string destination)
        {
            var sales = await _context.BookingSet.Where(s => s.Flight.Destination.Equals(destination)).Select(f => f.Flight.FlightId).ToListAsync();
            double avg = _context.BookingSet.Where(e => sales.Contains(e.Flight.FlightId)).Average(t => t.SalePrice);
            return avg;
        }


    }

}
