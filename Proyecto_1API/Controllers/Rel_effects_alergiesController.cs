using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_1API.Data;
using Proyecto_1API.Models;

namespace Proyecto_1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Rel_effects_alergiesController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public Rel_effects_alergiesController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/Rel_effects_alergies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<rel_effects_alergies>>> Getrel_effects_alergies()
        {
          if (_context.rel_effects_alergies == null)
          {
              return NotFound();
          }
            return await _context.rel_effects_alergies.ToListAsync();
        }

        // GET: api/Rel_effects_alergies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<rel_effects_alergies>> Getrel_effects_alergies(int id)
        {
          if (_context.rel_effects_alergies == null)
          {
              return NotFound();
          }
            var rel_effects_alergies = await _context.rel_effects_alergies.FindAsync(id);

            if (rel_effects_alergies == null)
            {
                return NotFound();
            }

            return rel_effects_alergies;
        }

        // PUT: api/Rel_effects_alergies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrel_effects_alergies(int id, rel_effects_alergies rel_effects_alergies)
        {
            if (id != rel_effects_alergies.id)
            {
                return BadRequest();
            }

            _context.Entry(rel_effects_alergies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rel_effects_alergiesExists(id))
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

        // POST: api/Rel_effects_alergies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<rel_effects_alergies>> Postrel_effects_alergies(rel_effects_alergies rel_effects_alergies)
        {
          if (_context.rel_effects_alergies == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.rel_effects_alergies'  is null.");
          }
            _context.rel_effects_alergies.Add(rel_effects_alergies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrel_effects_alergies", new { id = rel_effects_alergies.id }, rel_effects_alergies);
        }

        // DELETE: api/Rel_effects_alergies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterel_effects_alergies(int id)
        {
            if (_context.rel_effects_alergies == null)
            {
                return NotFound();
            }
            var rel_effects_alergies = await _context.rel_effects_alergies.FindAsync(id);
            if (rel_effects_alergies == null)
            {
                return NotFound();
            }

            _context.rel_effects_alergies.Remove(rel_effects_alergies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool rel_effects_alergiesExists(int id)
        {
            return (_context.rel_effects_alergies?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
