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
    public class AdvEventSymptomsController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public AdvEventSymptomsController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/AdvEventSymptoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdvEventSymptoms>>> GetAdvEventSymptoms()
        {
          if (_context.AdvEventSymptoms == null)
          {
              return NotFound();
          }
            return await _context.AdvEventSymptoms.ToListAsync();
        }

        // GET: api/AdvEventSymptoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvEventSymptoms>> GetAdvEventSymptoms(int id)
        {
          if (_context.AdvEventSymptoms == null)
          {
              return NotFound();
          }
            var advEventSymptoms = await _context.AdvEventSymptoms.FindAsync(id);

            if (advEventSymptoms == null)
            {
                return NotFound();
            }

            return advEventSymptoms;
        }

        // PUT: api/AdvEventSymptoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvEventSymptoms(int id, AdvEventSymptoms advEventSymptoms)
        {
            if (id != advEventSymptoms.id)
            {
                return BadRequest();
            }

            _context.Entry(advEventSymptoms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvEventSymptomsExists(id))
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

        // POST: api/AdvEventSymptoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdvEventSymptoms>> PostAdvEventSymptoms(AdvEventSymptoms advEventSymptoms)
        {
          if (_context.AdvEventSymptoms == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.AdvEventSymptoms'  is null.");
          }
            _context.AdvEventSymptoms.Add(advEventSymptoms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdvEventSymptoms", new { id = advEventSymptoms.id }, advEventSymptoms);
        }

        // DELETE: api/AdvEventSymptoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvEventSymptoms(int id)
        {
            if (_context.AdvEventSymptoms == null)
            {
                return NotFound();
            }
            var advEventSymptoms = await _context.AdvEventSymptoms.FindAsync(id);
            if (advEventSymptoms == null)
            {
                return NotFound();
            }

            _context.AdvEventSymptoms.Remove(advEventSymptoms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvEventSymptomsExists(int id)
        {
            return (_context.AdvEventSymptoms?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
