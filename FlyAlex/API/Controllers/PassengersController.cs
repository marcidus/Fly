using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlyAlex;
using FlyAlex.Models;

namespace API.Controllers
{
    public class PassengersController : Controller
    {
        private readonly Context _context;

        public PassengersController(Context context)
        {
            _context = context;
        }

        // GET: Passengers
        public async Task<IActionResult> Index()
        {
              return View(await _context.PassengerSet.ToListAsync());
        }

        // GET: Passengers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PassengerSet == null)
            {
                return NotFound();
            }

            var passenger = await _context.PassengerSet
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // GET: Passengers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,Birthday,Email,FullName,Surname,Country,Address")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PassengerSet == null)
            {
                return NotFound();
            }

            var passenger = await _context.PassengerSet.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,Birthday,Email,FullName,Surname,Country,Address")] Passenger passenger)
        {
            if (id != passenger.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passenger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengerExists(passenger.PersonID))
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
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PassengerSet == null)
            {
                return NotFound();
            }

            var passenger = await _context.PassengerSet
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PassengerSet == null)
            {
                return Problem("Entity set 'Context.PassengerSet'  is null.");
            }
            var passenger = await _context.PassengerSet.FindAsync(id);
            if (passenger != null)
            {
                _context.PassengerSet.Remove(passenger);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengerExists(int id)
        {
          return _context.PassengerSet.Any(e => e.PersonID == id);
        }
    }
}
