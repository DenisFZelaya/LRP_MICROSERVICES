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
    public class ReferenciasPersonalesController : ControllerBase
    {
        private readonly LOANSContext _context;

        public ReferenciasPersonalesController(LOANSContext context)
        {
            _context = context;
        }

        // GET: api/ReferenciasPersonales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReferenciasPersonales>>> GetReferenciasPersonales()
        {
          if (_context.ReferenciasPersonales == null)
          {
              return NotFound();
          }
            return await _context.ReferenciasPersonales.ToListAsync();
        }

        // GET: api/ReferenciasPersonales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferenciasPersonales>> GetReferenciasPersonales(int id)
        {
          if (_context.ReferenciasPersonales == null)
          {
              return NotFound();
          }
            var referenciasPersonales = await _context.ReferenciasPersonales.FindAsync(id);

            if (referenciasPersonales == null)
            {
                return NotFound();
            }

            return referenciasPersonales;
        }

        // PUT: api/ReferenciasPersonales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferenciasPersonales(int id, ReferenciasPersonales referenciasPersonales)
        {
            if (id != referenciasPersonales.Id)
            {
                return BadRequest();
            }

            _context.Entry(referenciasPersonales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenciasPersonalesExists(id))
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

        // POST: api/ReferenciasPersonales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReferenciasPersonales>> PostReferenciasPersonales(ReferenciasPersonales referenciasPersonales)
        {
          if (_context.ReferenciasPersonales == null)
          {
              return Problem("Entity set 'LOANSContext.ReferenciasPersonales'  is null.");
          }
            _context.ReferenciasPersonales.Add(referenciasPersonales);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferenciasPersonales", new { id = referenciasPersonales.Id }, referenciasPersonales);
        }

        // DELETE: api/ReferenciasPersonales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferenciasPersonales(int id)
        {
            if (_context.ReferenciasPersonales == null)
            {
                return NotFound();
            }
            var referenciasPersonales = await _context.ReferenciasPersonales.FindAsync(id);
            if (referenciasPersonales == null)
            {
                return NotFound();
            }

            _context.ReferenciasPersonales.Remove(referenciasPersonales);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferenciasPersonalesExists(int id)
        {
            return (_context.ReferenciasPersonales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
