using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlyAlex;
using FlyAlex.Models;
using API.Models;
using API.Extensions;

namespace API.Controllers
{
    public class FlightsController : Controller
    {
        private readonly Context _context;

        public FlightsController(Context context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
              return View(await _context.FlightSet.ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FlightSet == null)
            {
                return NotFound();
            }

            var flight = await _context.FlightSet
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,Date,Depart,Destination,Price,FlightNo,Occupation,NbrSeat,FreeSeat")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FlightSet == null)
            {
                return NotFound();
            }

            var flight = await _context.FlightSet.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,Date,Depart,Destination,Price,FlightNo,Occupation,NbrSeat,FreeSeat")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FlightSet == null)
            {
                return NotFound();
            }

            var flight = await _context.FlightSet
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FlightSet == null)
            {
                return Problem("Entity set 'Context.FlightSet'  is null.");
            }
            var flight = await _context.FlightSet.FindAsync(id);
            if (flight != null)
            {
                _context.FlightSet.Remove(flight);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
          return _context.FlightSet.Any(e => e.FlightId == id);
        }


        // a. Return all flights 
        [HttpGet("GetAvailableFlights")]
        public async Task<ActionResult<List<Flight>>> GetAvailableFlights()
        {
            var flightsAvailableList = await _context.FlightSet.Where(f => f.Occupation > 0 && f.Date > DateTime.Now).ToListAsync();
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
            if (p == null || f == null)
            {
                return NotFound();
            }
            Booking booking = new Booking();
            booking.Passenger.PersonID = p.PersonID;
            booking.Passenger = p;
            booking.Flight = f;
            booking.SalePrice = calculatePrice(f);
            _context.BookingSet.Add(booking);
            f.FreeSeat -= 1;
            f.Occupation = (Convert.ToDouble(f.NbrSeat) - Convert.ToDouble(f.FreeSeat)) / Convert.ToDouble(f.NbrSeat);
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

        //f.
        [HttpGet("FinalTicket/{destination}")]
        public async Task<ActionResult<IEnumerable<FinalTicket>>> GetFinalTicket(string destination)
        {

            var flights = await _context.FlightSet.Where(x => x.Destination.ToLower().Equals(destination.ToLower())).ToListAsync();
            List<FinalTicket> result = new List<FinalTicket>();
            foreach (var flight in flights)
            {
                result.AddRange(flight.ConvertToFinalTicket());
            }
            return result;
        }

    }
}
