using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndReact.Models;

namespace BackEndReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomotoresController : ControllerBase
    {
        private readonly BackEndReactDbContext _context;

        public AutomotoresController(BackEndReactDbContext context)
        {
            _context = context;
        }

        // GET: api/Automotores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automotor>>> GetAutomotor()
        {
            return await _context.Automotor.ToListAsync();
        }

        // GET: api/Automotores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Automotor>> GetAutomotor(int id)
        {
            var automotor = await _context.Automotor.FindAsync(id);

            if (automotor == null)
            {
                return NotFound();
            }

            return automotor;
        }

        // PUT: api/Automotores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutomotor(int id, Automotor automotor)
        {
            if (id != automotor.Id)
            {
                return BadRequest();
            }

            _context.Entry(automotor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomotorExists(id))
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

        // POST: api/Automotores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Automotor>> PostAutomotor(Automotor automotor)
        {
            _context.Automotor.Add(automotor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutomotor", new { id = automotor.Id }, automotor);
        }

        // DELETE: api/Automotores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Automotor>> DeleteAutomotor(int id)
        {
            var automotor = await _context.Automotor.FindAsync(id);
            if (automotor == null)
            {
                return NotFound();
            }

            _context.Automotor.Remove(automotor);
            await _context.SaveChangesAsync();

            return automotor;
        }

        private bool AutomotorExists(int id)
        {
            return _context.Automotor.Any(e => e.Id == id);
        }
    }
}
