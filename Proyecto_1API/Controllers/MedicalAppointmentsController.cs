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
    public class MedicalAppointmentsController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public MedicalAppointmentsController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/MedicalAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalAppointments>>> GetMedicalAppointments()
        {
          if (_context.MedicalAppointments == null)
          {
              return NotFound();
          }
            return await _context.MedicalAppointments.ToListAsync();
        }

        // GET: api/MedicalAppointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalAppointments>> GetMedicalAppointments(int id)
        {
          if (_context.MedicalAppointments == null)
          {
              return NotFound();
          }
            var medicalAppointments = await _context.MedicalAppointments.FindAsync(id);

            if (medicalAppointments == null)
            {
                return NotFound();
            }

            return medicalAppointments;
        }

        // PUT: api/MedicalAppointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalAppointments(int id, MedicalAppointments medicalAppointments)
        {
            if (id != medicalAppointments.id)
            {
                return BadRequest();
            }

            _context.Entry(medicalAppointments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalAppointmentsExists(id))
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

        // POST: api/MedicalAppointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicalAppointments>> PostMedicalAppointments(MedicalAppointments medicalAppointments)
        {
          if (_context.MedicalAppointments == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.MedicalAppointments'  is null.");
          }
            _context.MedicalAppointments.Add(medicalAppointments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalAppointments", new { id = medicalAppointments.id }, medicalAppointments);
        }

        // DELETE: api/MedicalAppointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalAppointments(int id)
        {
            if (_context.MedicalAppointments == null)
            {
                return NotFound();
            }
            var medicalAppointments = await _context.MedicalAppointments.FindAsync(id);
            if (medicalAppointments == null)
            {
                return NotFound();
            }

            _context.MedicalAppointments.Remove(medicalAppointments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalAppointmentsExists(int id)
        {
            return (_context.MedicalAppointments?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
