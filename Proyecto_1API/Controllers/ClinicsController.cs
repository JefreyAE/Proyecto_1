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
    public class ClinicsController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public ClinicsController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/Clinics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinics>>> GetClinics()
        {
          if (_context.Clinics == null)
          {
              return NotFound();
          }
            return await _context.Clinics.ToListAsync();
        }

        // GET: api/Clinics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinics>> GetClinics(int id)
        {
          if (_context.Clinics == null)
          {
              return NotFound();
          }
            var clinics = await _context.Clinics.FindAsync(id);

            if (clinics == null)
            {
                return NotFound();
            }

            return clinics;
        }

        [HttpGet("legal_certificate/{id}")]
        public async Task<ActionResult<Clinics>> GetClinicsByCertificate(string? id)
        {
            if (_context.Clinics == null)
            {
                return NotFound();
            }
            var clinic = await _context.Clinics.SingleOrDefaultAsync(s => s.legal_certificate == id);

            if (clinic == null)
            {
                return NotFound();
            }

            return clinic;
        }

        [HttpGet("clinic_name/{name}")]
        public async Task<ActionResult<Clinics>> GetClinicsByName(string? name)
        {
            if (_context.Clinics == null)
            {
                return NotFound();
            }
            var clinic = await _context.Clinics.SingleOrDefaultAsync(s => s.name == name);

            if (clinic == null)
            {
                return NotFound();
            }

            return clinic;
        }

        // PUT: api/Clinics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinics(int id, Clinics clinics)
        {
            if (id != clinics.id)
            {
                return BadRequest();
            }

            _context.Entry(clinics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicsExists(id))
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

        // POST: api/Clinics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clinics>> PostClinics(Clinics clinics)
        {
          if (_context.Clinics == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.Clinics'  is null.");
          }
            _context.Clinics.Add(clinics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClinics", new { id = clinics.id }, clinics);
        }

        // DELETE: api/Clinics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinics(int id)
        {
            if (_context.Clinics == null)
            {
                return NotFound();
            }
            var clinics = await _context.Clinics.FindAsync(id);
            if (clinics == null)
            {
                return NotFound();
            }

            _context.Clinics.Remove(clinics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClinicsExists(int id)
        {
            return (_context.Clinics?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
