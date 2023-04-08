using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loans.API.Data;
using Loans.API.Infraestructure.DBModels;

namespace Loans.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvalesController : ControllerBase
    {
        private readonly LOANSContext _context;

        public AvalesController(LOANSContext context)
        {
            _context = context;
        }

        // GET: api/Avales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avales>>> GetAvales()
        {
          if (_context.Avales == null)
          {
              return NotFound();
          }
            return await _context.Avales.ToListAsync();
        }

        // GET: api/Avales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avales>> GetAvales(int id)
        {
          if (_context.Avales == null)
          {
              return NotFound();
          }
            var avales = await _context.Avales.FindAsync(id);

            if (avales == null)
            {
                return NotFound();
            }

            return avales;
        }

        // PUT: api/Avales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvales(int id, Avales avales)
        {
            if (id != avales.Id)
            {
                return BadRequest();
            }

            _context.Entry(avales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvalesExists(id))
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

        // POST: api/Avales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avales>> PostAvales(Avales avales)
        {
          if (_context.Avales == null)
          {
              return Problem("Entity set 'LOANSContext.Avales'  is null.");
          }
            _context.Avales.Add(avales);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvales", new { id = avales.Id }, avales);
        }

        // DELETE: api/Avales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvales(int id)
        {
            if (_context.Avales == null)
            {
                return NotFound();
            }
            var avales = await _context.Avales.FindAsync(id);
            if (avales == null)
            {
                return NotFound();
            }

            _context.Avales.Remove(avales);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvalesExists(int id)
        {
            return (_context.Avales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
