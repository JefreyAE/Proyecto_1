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
    public class MedicsController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public MedicsController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/Medics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medics>>> GetMedics()
        {
          if (_context.Medics == null)
          {
              return NotFound();
          }
            return await _context.Medics.ToListAsync();
        }

        // GET: api/Medics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medics>> GetMedics(int id)
        {
          if (_context.Medics == null)
          {
              return NotFound();
          }
            var medics = await _context.Medics.FindAsync(id);

            if (medics == null)
            {
                return NotFound();
            }

            return medics;
        }

        //[Route("Medics/id_number/{id_number}")] 
        [HttpGet("id_number/{id_number}")]
        public async Task<ActionResult<Medics>> GetMedicsByIdNumber(string? id_number)
        {
            if (_context.Medics == null)
            {
                return NotFound();
            }

            var medics = await _context.Medics.SingleOrDefaultAsync(s => s.id_number == id_number);

            if (medics == null)
            {
                return NotFound();
            }

            return medics;
        }

        //[Route("Medics/professional_code/{code}")] 
        [HttpGet("professional_code/{code}")]
        public async Task<ActionResult<Medics>> GetMedicsByIdProfessionalCode(string? code)
        {
            if (_context.Medics == null)
            {
                return NotFound();
            }

            var medics = await _context.Medics.SingleOrDefaultAsync(s => s.professional_code == code);

            if (medics == null)
            {
                return NotFound();
            }

            return medics;
        }

        // PUT: api/Medics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedics(int id, Medics medics)
        {
            if (id != medics.id)
            {
                return BadRequest();
            }

            _context.Entry(medics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicsExists(id))
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

        // POST: api/Medics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medics>> PostMedics(Medics medics)
        {
          if (_context.Medics == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.Medics'  is null.");
          }
            _context.Medics.Add(medics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedics", new { id = medics.id }, medics);
        }

        // DELETE: api/Medics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedics(int id)
        {
            if (_context.Medics == null)
            {
                return NotFound();
            }
            var medics = await _context.Medics.FindAsync(id);
            if (medics == null)
            {
                return NotFound();
            }

            _context.Medics.Remove(medics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicsExists(int id)
        {
            return (_context.Medics?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
