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
    public class EvaluacionFinancierasController : ControllerBase
    {
        private readonly LOANSContext _context;

        public EvaluacionFinancierasController(LOANSContext context)
        {
            _context = context;
        }

        // GET: api/EvaluacionFinancieras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluacionFinanciera>>> GetEvaluacionFinanciera()
        {
          if (_context.EvaluacionFinanciera == null)
          {
              return NotFound();
          }
            return await _context.EvaluacionFinanciera.ToListAsync();
        }

        // GET: api/EvaluacionFinancieras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluacionFinanciera>> GetEvaluacionFinanciera(int id)
        {
          if (_context.EvaluacionFinanciera == null)
          {
              return NotFound();
          }
            var evaluacionFinanciera = await _context.EvaluacionFinanciera.FindAsync(id);

            if (evaluacionFinanciera == null)
            {
                return NotFound();
            }

            return evaluacionFinanciera;
        }

        // PUT: api/EvaluacionFinancieras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluacionFinanciera(int id, EvaluacionFinanciera evaluacionFinanciera)
        {
            if (id != evaluacionFinanciera.Id)
            {
                return BadRequest();
            }

            _context.Entry(evaluacionFinanciera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluacionFinancieraExists(id))
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

        // POST: api/EvaluacionFinancieras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EvaluacionFinanciera>> PostEvaluacionFinanciera(EvaluacionFinanciera evaluacionFinanciera)
        {
          if (_context.EvaluacionFinanciera == null)
          {
              return Problem("Entity set 'LOANSContext.EvaluacionFinanciera'  is null.");
          }
            _context.EvaluacionFinanciera.Add(evaluacionFinanciera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvaluacionFinanciera", new { id = evaluacionFinanciera.Id }, evaluacionFinanciera);
        }

        // DELETE: api/EvaluacionFinancieras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluacionFinanciera(int id)
        {
            if (_context.EvaluacionFinanciera == null)
            {
                return NotFound();
            }
            var evaluacionFinanciera = await _context.EvaluacionFinanciera.FindAsync(id);
            if (evaluacionFinanciera == null)
            {
                return NotFound();
            }

            _context.EvaluacionFinanciera.Remove(evaluacionFinanciera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvaluacionFinancieraExists(int id)
        {
            return (_context.EvaluacionFinanciera?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
