using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Logs.API.Data;
using Logs.API.Models;

namespace Logs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsAplicacionsController : ControllerBase
    {
        private readonly LOGSContext _context;

        public LogsAplicacionsController(LOGSContext context)
        {
            _context = context;
        }

        // GET: api/LogsAplicacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogsAplicacion>>> GetLogsAplicacion()
        {
          if (_context.LogsAplicacion == null)
          {
              return NotFound();
          }
            return await _context.LogsAplicacion.ToListAsync();
        }

        // GET: api/LogsAplicacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogsAplicacion>> GetLogsAplicacion(int id)
        {
          if (_context.LogsAplicacion == null)
          {
              return NotFound();
          }
            var logsAplicacion = await _context.LogsAplicacion.FindAsync(id);

            if (logsAplicacion == null)
            {
                return NotFound();
            }

            return logsAplicacion;
        }

        // PUT: api/LogsAplicacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogsAplicacion(int id, LogsAplicacion logsAplicacion)
        {
            if (id != logsAplicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(logsAplicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogsAplicacionExists(id))
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

        // POST: api/LogsAplicacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogsAplicacion>> PostLogsAplicacion(LogsAplicacion logsAplicacion)
        {
          if (_context.LogsAplicacion == null)
          {
              return Problem("Entity set 'LOGSContext.LogsAplicacion'  is null.");
          }
            _context.LogsAplicacion.Add(logsAplicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogsAplicacion", new { id = logsAplicacion.Id }, logsAplicacion);
        }

        // DELETE: api/LogsAplicacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogsAplicacion(int id)
        {
            if (_context.LogsAplicacion == null)
            {
                return NotFound();
            }
            var logsAplicacion = await _context.LogsAplicacion.FindAsync(id);
            if (logsAplicacion == null)
            {
                return NotFound();
            }

            _context.LogsAplicacion.Remove(logsAplicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogsAplicacionExists(int id)
        {
            return (_context.LogsAplicacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
