﻿using System;
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
    public class PaiementsController : ControllerBase
    {
        private readonly Context _context;

        public PaiementsController(Context context)
        {
            _context = context;
        }

        // GET: api/Paiements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paiement>>> GetPaiementSet()
        {
            return await _context.PaiementSet.ToListAsync();
        }

        // GET: api/Paiements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paiement>> GetPaiement(int id)
        {
            var paiement = await _context.PaiementSet.FindAsync(id);

            if (paiement == null)
            {
                return NotFound();
            }

            return paiement;
        }

        // PUT: api/Paiements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaiement(int id, Paiement paiement)
        {
            if (id != paiement.PaiementId)
            {
                return BadRequest();
            }

            _context.Entry(paiement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaiementExists(id))
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

        // POST: api/Paiements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paiement>> PostPaiement(Paiement paiement)
        {
            _context.PaiementSet.Add(paiement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaiement", new { id = paiement.PaiementId }, paiement);
        }

        // DELETE: api/Paiements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaiement(int id)
        {
            var paiement = await _context.PaiementSet.FindAsync(id);
            if (paiement == null)
            {
                return NotFound();
            }

            _context.PaiementSet.Remove(paiement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaiementExists(int id)
        {
            return _context.PaiementSet.Any(e => e.PaiementId == id);
        }
    }
}
