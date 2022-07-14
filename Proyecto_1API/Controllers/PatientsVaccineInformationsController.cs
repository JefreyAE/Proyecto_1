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
    public class PatientsVaccineInformationsController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public PatientsVaccineInformationsController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/PatientsVaccineInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientsVaccineInformation>>> GetPatientsVaccineInformation()
        {
          if (_context.PatientsVaccineInformation == null)
          {
              return NotFound();
          }
            return await _context.PatientsVaccineInformation.ToListAsync();
        }

        // GET: api/PatientsVaccineInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientsVaccineInformation>> GetPatientsVaccineInformation(int id)
        {
          if (_context.PatientsVaccineInformation == null)
          {
              return NotFound();
          }
            var patientsVaccineInformation = await _context.PatientsVaccineInformation.FindAsync(id);

            if (patientsVaccineInformation == null)
            {
                return NotFound();
            }

            return patientsVaccineInformation;
        }

        // PUT: api/PatientsVaccineInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientsVaccineInformation(int id, PatientsVaccineInformation patientsVaccineInformation)
        {
            if (id != patientsVaccineInformation.id)
            {
                return BadRequest();
            }

            _context.Entry(patientsVaccineInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientsVaccineInformationExists(id))
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

        // POST: api/PatientsVaccineInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientsVaccineInformation>> PostPatientsVaccineInformation(PatientsVaccineInformation patientsVaccineInformation)
        {
          if (_context.PatientsVaccineInformation == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.PatientsVaccineInformation'  is null.");
          }
            _context.PatientsVaccineInformation.Add(patientsVaccineInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientsVaccineInformation", new { id = patientsVaccineInformation.id }, patientsVaccineInformation);
        }

        // DELETE: api/PatientsVaccineInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientsVaccineInformation(int id)
        {
            if (_context.PatientsVaccineInformation == null)
            {
                return NotFound();
            }
            var patientsVaccineInformation = await _context.PatientsVaccineInformation.FindAsync(id);
            if (patientsVaccineInformation == null)
            {
                return NotFound();
            }

            _context.PatientsVaccineInformation.Remove(patientsVaccineInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientsVaccineInformationExists(int id)
        {
            return (_context.PatientsVaccineInformation?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
