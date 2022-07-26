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
    public class Rel_effects_symptomsController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public Rel_effects_symptomsController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/Rel_effects_symptoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<rel_effects_symptoms>>> Getrel_effects_symptoms()
        {
          if (_context.rel_effects_symptoms == null)
          {
              return NotFound();
          }
            return await _context.rel_effects_symptoms.ToListAsync();
        }

        // GET: api/Rel_effects_symptoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<rel_effects_symptoms>> Getrel_effects_symptoms(int id)
        {
          if (_context.rel_effects_symptoms == null)
          {
              return NotFound();
          }
            var rel_effects_symptoms = await _context.rel_effects_symptoms.FindAsync(id);

            if (rel_effects_symptoms == null)
            {
                return NotFound();
            }

            return rel_effects_symptoms;
        }

        // PUT: api/Rel_effects_symptoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrel_effects_symptoms(int id, rel_effects_symptoms rel_effects_symptoms)
        {
            if (id != rel_effects_symptoms.id)
            {
                return BadRequest();
            }

            _context.Entry(rel_effects_symptoms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rel_effects_symptomsExists(id))
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

        // POST: api/Rel_effects_symptoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<rel_effects_symptoms>> Postrel_effects_symptoms(rel_effects_symptoms rel_effects_symptoms)
        {
          if (_context.rel_effects_symptoms == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.rel_effects_symptoms'  is null.");
          }
            _context.rel_effects_symptoms.Add(rel_effects_symptoms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrel_effects_symptoms", new { id = rel_effects_symptoms.id }, rel_effects_symptoms);
        }

        // DELETE: api/Rel_effects_symptoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterel_effects_symptoms(int id)
        {
            if (_context.rel_effects_symptoms == null)
            {
                return NotFound();
            }
            var rel_effects_symptoms = await _context.rel_effects_symptoms.FindAsync(id);
            if (rel_effects_symptoms == null)
            {
                return NotFound();
            }

            _context.rel_effects_symptoms.Remove(rel_effects_symptoms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool rel_effects_symptomsExists(int id)
        {
            return (_context.rel_effects_symptoms?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
