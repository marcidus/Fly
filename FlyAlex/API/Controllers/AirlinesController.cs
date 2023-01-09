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
    public class AirlinesController : Controller
    {
        private readonly Context _context;

        public AirlinesController(Context context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
              return View(await _context.AirlineSet.ToListAsync());
        }

        // GET: Airlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AirlineSet == null)
            {
                return NotFound();
            }

            var airline = await _context.AirlineSet
                .FirstOrDefaultAsync(m => m.AirlineID == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // GET: Airlines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirlineID,Name")] Airline airline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airline);
        }

        // GET: Airlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AirlineSet == null)
            {
                return NotFound();
            }

            var airline = await _context.AirlineSet.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }
            return View(airline);
        }

        // POST: Airlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AirlineID,Name")] Airline airline)
        {
            if (id != airline.AirlineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineExists(airline.AirlineID))
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
            return View(airline);
        }

        // GET: Airlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AirlineSet == null)
            {
                return NotFound();
            }

            var airline = await _context.AirlineSet
                .FirstOrDefaultAsync(m => m.AirlineID == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AirlineSet == null)
            {
                return Problem("Entity set 'Context.AirlineSet'  is null.");
            }
            var airline = await _context.AirlineSet.FindAsync(id);
            if (airline != null)
            {
                _context.AirlineSet.Remove(airline);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineExists(int id)
        {
          return _context.AirlineSet.Any(e => e.AirlineID == id);
        }
    }
}
