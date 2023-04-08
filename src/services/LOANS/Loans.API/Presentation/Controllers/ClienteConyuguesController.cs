using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loans.API.Infraestructure.DBModels;
using Loans.API.Data;

namespace Loans.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteConyuguesController : ControllerBase
    {
        private readonly LOANSContext _context;

        public ClienteConyuguesController(LOANSContext context)
        {
            _context = context;
        }

        // GET: api/ClienteConyugues
        [HttpGet]
        public async Task<object> GetClienteConyugue()
        {
            if (_context.ClienteConyugue == null)
            {
                return NotFound();
            }
            return await _context.ClienteConyugue.ToListAsync();
        }

        // GET: api/ClienteConyugues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteConyugue>> GetClienteConyugue(int id)
        {
            if (_context.ClienteConyugue == null)
            {
                return NotFound();
            }
            var clienteConyugue = await _context.ClienteConyugue.FindAsync(id);

            if (clienteConyugue == null)
            {
                return NotFound();
            }

            return clienteConyugue;
        }

        // PUT: api/ClienteConyugues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteConyugue(int id, ClienteConyugue clienteConyugue)
        {
            if (id != clienteConyugue.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteConyugue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteConyugueExists(id))
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

        // POST: api/ClienteConyugues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<object> PostClienteConyugue(ClienteConyugue clienteConyugue)
        {
            if (_context.ClienteConyugue == null)
            {
                return Problem("Entity set 'LOANSContext.ClienteConyugue'  is null.");
            }
            _context.ClienteConyugue.Add(clienteConyugue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteConyugue", new { id = clienteConyugue.Id }, clienteConyugue);
        }

        // DELETE: api/ClienteConyugues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteConyugue(int id)
        {
            if (_context.ClienteConyugue == null)
            {
                return NotFound();
            }
            var clienteConyugue = await _context.ClienteConyugue.FindAsync(id);
            if (clienteConyugue == null)
            {
                return NotFound();
            }

            _context.ClienteConyugue.Remove(clienteConyugue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteConyugueExists(int id)
        {
            return (_context.ClienteConyugue?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
