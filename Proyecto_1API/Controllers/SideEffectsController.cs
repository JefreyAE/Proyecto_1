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
    public class SideEffectsController : ControllerBase
    {
        private readonly Proyecto_1APIContext _context;

        public SideEffectsController(Proyecto_1APIContext context)
        {
            _context = context;
        }

        // GET: api/SideEffects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SideEffects>>> GetSideEffects()
        {
          if (_context.SideEffects == null)
          {
              return NotFound();
          }
            return await _context.SideEffects.ToListAsync();
        }

        // GET: api/SideEffects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SideEffects>> GetSideEffects(int id)
        {
          if (_context.SideEffects == null)
          {
              return NotFound();
          }
            var sideEffects = await _context.SideEffects.FindAsync(id);

            if (sideEffects == null)
            {
                return NotFound();
            }

            return sideEffects;
        }

        // PUT: api/SideEffects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSideEffects(int id, SideEffects sideEffects)
        {
            if (id != sideEffects.id)
            {
                return BadRequest();
            }

            _context.Entry(sideEffects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SideEffectsExists(id))
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

        // POST: api/SideEffects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SideEffects>> PostSideEffects(SideEffects sideEffects)
        {
          if (_context.SideEffects == null)
          {
              return Problem("Entity set 'Proyecto_1APIContext.SideEffects'  is null.");
          }
            _context.SideEffects.Add(sideEffects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSideEffects", new { id = sideEffects.id }, sideEffects);
        }

        // DELETE: api/SideEffects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSideEffects(int id)
        {
            if (_context.SideEffects == null)
            {
                return NotFound();
            }
            var sideEffects = await _context.SideEffects.FindAsync(id);
            if (sideEffects == null)
            {
                return NotFound();
            }

            _context.SideEffects.Remove(sideEffects);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SideEffectsExists(int id)
        {
            return (_context.SideEffects?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
