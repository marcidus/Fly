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
    public class PilotsController : Controller
    {
        private readonly Context _context;

        public PilotsController(Context context)
        {
            _context = context;
        }

        // GET: Pilots
        public async Task<IActionResult> Index()
        {
              return View(await _context.PilotSet.ToListAsync());
        }

        // GET: Pilots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PilotSet == null)
            {
                return NotFound();
            }

            var pilot = await _context.PilotSet
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (pilot == null)
            {
                return NotFound();
            }

            return View(pilot);
        }

        // GET: Pilots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pilots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,Birthday,Email,FullName,Surname,Country,Address")] Pilot pilot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pilot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pilot);
        }

        // GET: Pilots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PilotSet == null)
            {
                return NotFound();
            }

            var pilot = await _context.PilotSet.FindAsync(id);
            if (pilot == null)
            {
                return NotFound();
            }
            return View(pilot);
        }

        // POST: Pilots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,Birthday,Email,FullName,Surname,Country,Address")] Pilot pilot)
        {
            if (id != pilot.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pilot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilotExists(pilot.PersonID))
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
            return View(pilot);
        }

        // GET: Pilots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PilotSet == null)
            {
                return NotFound();
            }

            var pilot = await _context.PilotSet
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (pilot == null)
            {
                return NotFound();
            }

            return View(pilot);
        }

        // POST: Pilots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PilotSet == null)
            {
                return Problem("Entity set 'Context.PilotSet'  is null.");
            }
            var pilot = await _context.PilotSet.FindAsync(id);
            if (pilot != null)
            {
                _context.PilotSet.Remove(pilot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilotExists(int id)
        {
          return _context.PilotSet.Any(e => e.PersonID == id);
        }
    }
}
