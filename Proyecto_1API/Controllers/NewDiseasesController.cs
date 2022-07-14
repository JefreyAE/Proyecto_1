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
    public class NewDiseasesController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public NewDiseasesController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/NewDiseases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewDiseases>>> GetNewDiseases()
        {
          if (_context.NewDiseases == null)
          {
              return NotFound();
          }
            return await _context.NewDiseases.ToListAsync();
        }

        // GET: api/NewDiseases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewDiseases>> GetNewDiseases(int id)
        {
          if (_context.NewDiseases == null)
          {
              return NotFound();
          }
            var newDiseases = await _context.NewDiseases.FindAsync(id);

            if (newDiseases == null)
            {
                return NotFound();
            }

            return newDiseases;
        }

        // PUT: api/NewDiseases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewDiseases(int id, NewDiseases newDiseases)
        {
            if (id != newDiseases.id)
            {
                return BadRequest();
            }

            _context.Entry(newDiseases).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewDiseasesExists(id))
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

        // POST: api/NewDiseases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewDiseases>> PostNewDiseases(NewDiseases newDiseases)
        {
          if (_context.NewDiseases == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.NewDiseases'  is null.");
          }
            _context.NewDiseases.Add(newDiseases);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewDiseases", new { id = newDiseases.id }, newDiseases);
        }

        // DELETE: api/NewDiseases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewDiseases(int id)
        {
            if (_context.NewDiseases == null)
            {
                return NotFound();
            }
            var newDiseases = await _context.NewDiseases.FindAsync(id);
            if (newDiseases == null)
            {
                return NotFound();
            }

            _context.NewDiseases.Remove(newDiseases);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewDiseasesExists(int id)
        {
            return (_context.NewDiseases?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
