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
    public class AlergiesController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public AlergiesController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/Alergies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alergies>>> GetAlergies()
        {
          if (_context.Alergies == null)
          {
              return NotFound();
          }
            return await _context.Alergies.ToListAsync();
        }

        // GET: api/Alergies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alergies>> GetAlergies(int id)
        {
          if (_context.Alergies == null)
          {
              return NotFound();
          }
            var alergies = await _context.Alergies.FindAsync(id);

            if (alergies == null)
            {
                return NotFound();
            }

            return alergies;
        }

        // PUT: api/Alergies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlergies(int id, Alergies alergies)
        {
            if (id != alergies.id)
            {
                return BadRequest();
            }

            _context.Entry(alergies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlergiesExists(id))
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

        // POST: api/Alergies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alergies>> PostAlergies(Alergies alergies)
        {
          if (_context.Alergies == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.Alergies'  is null.");
          }
            _context.Alergies.Add(alergies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlergies", new { id = alergies.id }, alergies);
        }

        // DELETE: api/Alergies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlergies(int id)
        {
            if (_context.Alergies == null)
            {
                return NotFound();
            }
            var alergies = await _context.Alergies.FindAsync(id);
            if (alergies == null)
            {
                return NotFound();
            }

            _context.Alergies.Remove(alergies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlergiesExists(int id)
        {
            return (_context.Alergies?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
