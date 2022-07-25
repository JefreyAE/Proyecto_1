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
    public class Rel_effects_event_symptomsController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public Rel_effects_event_symptomsController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/Rel_effects_event_symptoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<rel_effects_event_symptoms>>> Getrel_effects_event_symptoms()
        {
          if (_context.rel_effects_event_symptoms == null)
          {
              return NotFound();
          }
            return await _context.rel_effects_event_symptoms.ToListAsync();
        }

        // GET: api/Rel_effects_event_symptoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<rel_effects_event_symptoms>> Getrel_effects_event_symptoms(int id)
        {
          if (_context.rel_effects_event_symptoms == null)
          {
              return NotFound();
          }
            var rel_effects_event_symptoms = await _context.rel_effects_event_symptoms.FindAsync(id);

            if (rel_effects_event_symptoms == null)
            {
                return NotFound();
            }

            return rel_effects_event_symptoms;
        }

        // PUT: api/Rel_effects_event_symptoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrel_effects_event_symptoms(int id, rel_effects_event_symptoms rel_effects_event_symptoms)
        {
            if (id != rel_effects_event_symptoms.id)
            {
                return BadRequest();
            }

            _context.Entry(rel_effects_event_symptoms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rel_effects_event_symptomsExists(id))
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

        // POST: api/Rel_effects_event_symptoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<rel_effects_event_symptoms>> Postrel_effects_event_symptoms(rel_effects_event_symptoms rel_effects_event_symptoms)
        {
          if (_context.rel_effects_event_symptoms == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.rel_effects_event_symptoms'  is null.");
          }
            _context.rel_effects_event_symptoms.Add(rel_effects_event_symptoms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrel_effects_event_symptoms", new { id = rel_effects_event_symptoms.id }, rel_effects_event_symptoms);
        }

        // DELETE: api/Rel_effects_event_symptoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterel_effects_event_symptoms(int id)
        {
            if (_context.rel_effects_event_symptoms == null)
            {
                return NotFound();
            }
            var rel_effects_event_symptoms = await _context.rel_effects_event_symptoms.FindAsync(id);
            if (rel_effects_event_symptoms == null)
            {
                return NotFound();
            }

            _context.rel_effects_event_symptoms.Remove(rel_effects_event_symptoms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool rel_effects_event_symptomsExists(int id)
        {
            return (_context.rel_effects_event_symptoms?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
