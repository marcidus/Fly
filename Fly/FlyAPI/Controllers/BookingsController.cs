using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fly;
using Fly.Models;

namespace FlyAPI.Controllers
{
    public class BookingsController : Controller
    {
        private readonly Context _context;

        public BookingsController(Context context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var context = _context.BookingSet.Include(b => b.Passenger);
            return View(await context.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookingSet == null)
            {
                return NotFound();
            }

            var booking = await _context.BookingSet
                .Include(b => b.Passenger)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["PassengerID"] = new SelectList(_context.PassengerSet, "PersonID", "Adresse");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,SalePrice,PassengerID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PassengerID"] = new SelectList(_context.PassengerSet, "PersonID", "Adresse", booking.PassengerID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookingSet == null)
            {
                return NotFound();
            }

            var booking = await _context.BookingSet.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["PassengerID"] = new SelectList(_context.PassengerSet, "PersonID", "Adresse", booking.PassengerID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,SalePrice,PassengerID")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
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
            ViewData["PassengerID"] = new SelectList(_context.PassengerSet, "PersonID", "Adresse", booking.PassengerID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookingSet == null)
            {
                return NotFound();
            }

            var booking = await _context.BookingSet
                .Include(b => b.Passenger)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookingSet == null)
            {
                return Problem("Entity set 'Context.BookingSet'  is null.");
            }
            var booking = await _context.BookingSet.FindAsync(id);
            if (booking != null)
            {
                _context.BookingSet.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return _context.BookingSet.Any(e => e.BookingID == id);
        }
    }
}
