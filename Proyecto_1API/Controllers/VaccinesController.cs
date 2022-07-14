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
    public class VaccinesController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public VaccinesController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/Vaccines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccines>>> GetVaccines()
        {
          if (_context.Vaccines == null)
          {
              return NotFound();
          }
            return await _context.Vaccines.ToListAsync();
        }

        // GET: api/Vaccines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccines>> GetVaccines(int id)
        {
          if (_context.Vaccines == null)
          {
              return NotFound();
          }
            var vaccines = await _context.Vaccines.FindAsync(id);

            if (vaccines == null)
            {
                return NotFound();
            }

            return vaccines;
        }

        // PUT: api/Vaccines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccines(int id, Vaccines vaccines)
        {
            if (id != vaccines.id)
            {
                return BadRequest();
            }

            _context.Entry(vaccines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccinesExists(id))
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

        // POST: api/Vaccines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaccines>> PostVaccines(Vaccines vaccines)
        {
          if (_context.Vaccines == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.Vaccines'  is null.");
          }
            _context.Vaccines.Add(vaccines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaccines", new { id = vaccines.id }, vaccines);
        }

        // DELETE: api/Vaccines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccines(int id)
        {
            if (_context.Vaccines == null)
            {
                return NotFound();
            }
            var vaccines = await _context.Vaccines.FindAsync(id);
            if (vaccines == null)
            {
                return NotFound();
            }

            _context.Vaccines.Remove(vaccines);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccinesExists(int id)
        {
            return (_context.Vaccines?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
