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
    public class SolicitudesController : ControllerBase
    {
        private readonly LOANSContext _context;

        public SolicitudesController(LOANSContext context)
        {
            _context = context;
        }

        // GET: api/Solicitudes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitudes>>> GetSolicitudes()
        {
          if (_context.Solicitudes == null)
          {
              return NotFound();
          }
            return await _context.Solicitudes.ToListAsync();
        }

        // GET: api/Solicitudes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitudes>> GetSolicitudes(int id)
        {
          if (_context.Solicitudes == null)
          {
              return NotFound();
          }
            var solicitudes = await _context.Solicitudes.FindAsync(id);

            if (solicitudes == null)
            {
                return NotFound();
            }

            return solicitudes;
        }

        // PUT: api/Solicitudes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitudes(int id, Solicitudes solicitudes)
        {
            if (id != solicitudes.Id)
            {
                return BadRequest();
            }

            _context.Entry(solicitudes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudesExists(id))
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

        // POST: api/Solicitudes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Solicitudes>> PostSolicitudes(Solicitudes solicitudes)
        {
          if (_context.Solicitudes == null)
          {
              return Problem("Entity set 'LOANSContext.Solicitudes'  is null.");
          }
            _context.Solicitudes.Add(solicitudes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitudes", new { id = solicitudes.Id }, solicitudes);
        }

        // DELETE: api/Solicitudes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitudes(int id)
        {
            if (_context.Solicitudes == null)
            {
                return NotFound();
            }
            var solicitudes = await _context.Solicitudes.FindAsync(id);
            if (solicitudes == null)
            {
                return NotFound();
            }

            _context.Solicitudes.Remove(solicitudes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolicitudesExists(int id)
        {
            return (_context.Solicitudes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
