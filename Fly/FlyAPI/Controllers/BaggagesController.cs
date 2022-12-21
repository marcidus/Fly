using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fly;

namespace FlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaggagesController : ControllerBase
    {
        private readonly Context _context;

        public BaggagesController(Context context)
        {
            _context = context;
        }

        // GET: api/Baggages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Baggage>>> GetBaggageSet()
        {
            return await _context.BaggageSet.ToListAsync();
        }

        // GET: api/Baggages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Baggage>> GetBaggage(int id)
        {
            var baggage = await _context.BaggageSet.FindAsync(id);

            if (baggage == null)
            {
                return NotFound();
            }

            return baggage;
        }

        // PUT: api/Baggages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaggage(int id, Baggage baggage)
        {
            if (id != baggage.BaggageId)
            {
                return BadRequest();
            }

            _context.Entry(baggage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaggageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Baggages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Baggage>> PostBaggage(Baggage baggage)
        {
            _context.BaggageSet.Add(baggage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaggage", new { id = baggage.BaggageId }, baggage);
        }

        // DELETE: api/Baggages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaggage(int id)
        {
            var baggage = await _context.BaggageSet.FindAsync(id);
            if (baggage == null)
            {
                return NotFound();
            }

            _context.BaggageSet.Remove(baggage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaggageExists(int id)
        {
            return _context.BaggageSet.Any(e => e.BaggageId == id);
        }
    }
}
