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
    public class Rel_effects_diseasesController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public Rel_effects_diseasesController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/Rel_effects_diseases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<rel_effects_diseases>>> Getrel_effects_diseases()
        {
          if (_context.rel_effects_diseases == null)
          {
              return NotFound();
          }
            return await _context.rel_effects_diseases.ToListAsync();
        }

        // GET: api/Rel_effects_diseases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<rel_effects_diseases>> Getrel_effects_diseases(int id)
        {
          if (_context.rel_effects_diseases == null)
          {
              return NotFound();
          }
            var rel_effects_diseases = await _context.rel_effects_diseases.FindAsync(id);

            if (rel_effects_diseases == null)
            {
                return NotFound();
            }

            return rel_effects_diseases;
        }

        // PUT: api/Rel_effects_diseases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrel_effects_diseases(int id, rel_effects_diseases rel_effects_diseases)
        {
            if (id != rel_effects_diseases.id)
            {
                return BadRequest();
            }

            _context.Entry(rel_effects_diseases).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rel_effects_diseasesExists(id))
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

        // POST: api/Rel_effects_diseases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<rel_effects_diseases>> Postrel_effects_diseases(rel_effects_diseases rel_effects_diseases)
        {
          if (_context.rel_effects_diseases == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.rel_effects_diseases'  is null.");
          }
            _context.rel_effects_diseases.Add(rel_effects_diseases);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrel_effects_diseases", new { id = rel_effects_diseases.id }, rel_effects_diseases);
        }

        // DELETE: api/Rel_effects_diseases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterel_effects_diseases(int id)
        {
            if (_context.rel_effects_diseases == null)
            {
                return NotFound();
            }
            var rel_effects_diseases = await _context.rel_effects_diseases.FindAsync(id);
            if (rel_effects_diseases == null)
            {
                return NotFound();
            }

            _context.rel_effects_diseases.Remove(rel_effects_diseases);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool rel_effects_diseasesExists(int id)
        {
            return (_context.rel_effects_diseases?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
