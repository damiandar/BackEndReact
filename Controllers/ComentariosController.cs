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
    public class ComentariosController : ControllerBase
    {
        private readonly BackEndReactDbContext _context;

        public ComentariosController(BackEndReactDbContext context)
        {
            _context = context;
        }

        // GET: api/Comentarioss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentario()
        {
            return await _context.Comentario.ToListAsync();
        }

        // GET: api/Comentarioss/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
            var comentario = await _context.Comentario.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return comentario;
        }

        // PUT: api/Comentarioss/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentario(int id, Comentario comentario)
        {
            if (id != comentario.id)
            {
                return BadRequest();
            }

            _context.Entry(comentario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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

        // POST: api/Comentarioss
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comentario>> PostComentario(Comentario comentario)
        {
            _context.Comentario.Add(comentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComentario", new { id = comentario.id }, comentario);
        }

        // DELETE: api/Comentarioss/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comentario>> DeleteComentario(int id)
        {
            var comentario = await _context.Comentario.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentario.Remove(comentario);
            await _context.SaveChangesAsync();

            return comentario;
        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentario.Any(e => e.id == id);
        }
    }
}
