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
    public class BaggagesController : Controller
    {
        private readonly Context _context;

        public BaggagesController(Context context)
        {
            _context = context;
        }

        // GET: Baggages
        public async Task<IActionResult> Index()
        {
              return View(await _context.BaggageSet.ToListAsync());
        }

        // GET: Baggages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BaggageSet == null)
            {
                return NotFound();
            }

            var baggage = await _context.BaggageSet
                .FirstOrDefaultAsync(m => m.BaggageID == id);
            if (baggage == null)
            {
                return NotFound();
            }

            return View(baggage);
        }

        // GET: Baggages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baggages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaggageID,BaggageWeight,BaggageSizer")] Baggage baggage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baggage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baggage);
        }

        // GET: Baggages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BaggageSet == null)
            {
                return NotFound();
            }

            var baggage = await _context.BaggageSet.FindAsync(id);
            if (baggage == null)
            {
                return NotFound();
            }
            return View(baggage);
        }

        // POST: Baggages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BaggageID,BaggageWeight,BaggageSizer")] Baggage baggage)
        {
            if (id != baggage.BaggageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baggage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaggageExists(baggage.BaggageID))
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
            return View(baggage);
        }

        // GET: Baggages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BaggageSet == null)
            {
                return NotFound();
            }

            var baggage = await _context.BaggageSet
                .FirstOrDefaultAsync(m => m.BaggageID == id);
            if (baggage == null)
            {
                return NotFound();
            }

            return View(baggage);
        }

        // POST: Baggages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BaggageSet == null)
            {
                return Problem("Entity set 'Context.BaggageSet'  is null.");
            }
            var baggage = await _context.BaggageSet.FindAsync(id);
            if (baggage != null)
            {
                _context.BaggageSet.Remove(baggage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaggageExists(int id)
        {
          return _context.BaggageSet.Any(e => e.BaggageID == id);
        }
    }
}
