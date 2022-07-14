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
    public class SymptomsController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public SymptomsController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/Symptoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Symptoms>>> GetSymptoms()
        {
          if (_context.Symptoms == null)
          {
              return NotFound();
          }
            return await _context.Symptoms.ToListAsync();
        }

        // GET: api/Symptoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Symptoms>> GetSymptoms(int id)
        {
          if (_context.Symptoms == null)
          {
              return NotFound();
          }
            var symptoms = await _context.Symptoms.FindAsync(id);

            if (symptoms == null)
            {
                return NotFound();
            }

            return symptoms;
        }

        // PUT: api/Symptoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSymptoms(int id, Symptoms symptoms)
        {
            if (id != symptoms.id)
            {
                return BadRequest();
            }

            _context.Entry(symptoms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SymptomsExists(id))
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

        // POST: api/Symptoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Symptoms>> PostSymptoms(Symptoms symptoms)
        {
          if (_context.Symptoms == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.Symptoms'  is null.");
          }
            _context.Symptoms.Add(symptoms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSymptoms", new { id = symptoms.id }, symptoms);
        }

        // DELETE: api/Symptoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSymptoms(int id)
        {
            if (_context.Symptoms == null)
            {
                return NotFound();
            }
            var symptoms = await _context.Symptoms.FindAsync(id);
            if (symptoms == null)
            {
                return NotFound();
            }

            _context.Symptoms.Remove(symptoms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SymptomsExists(int id)
        {
            return (_context.Symptoms?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
