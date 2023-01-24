using dsd03Razor2020Assessment.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RolesForAssessment.Data;

namespace RolesForAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Casts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cast>>> GetCast()
        {
            if (_context.Cast == null)
            {
                return NotFound();
            }

            // AddTestData.AddCastData(_context);
            return await _context.Cast.ToListAsync();
        }

        // GET: api/Casts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cast>> GetCast(Guid id)
        {
            if (_context.Cast == null)
            {
                return NotFound();
            }
            var cast = await _context.Cast.FindAsync(id);

            if (cast == null)
            {
                return NotFound();
            }

            return cast;
        }

        // PUT: api/Casts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCast(Guid id, Cast cast)
        {
            if (id != cast.Id)
            {
                return BadRequest();
            }

            _context.Entry(cast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CastExists(id))
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

        // POST: api/Casts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cast>> PostCast(Cast cast)
        {
            if (_context.Cast == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cast'  is null.");
            }
            _context.Cast.Add(cast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCast", new { id = cast.Id }, cast);
        }

        // DELETE: api/Casts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCast(Guid id)
        {
            if (_context.Cast == null)
            {
                return NotFound();
            }
            var cast = await _context.Cast.FindAsync(id);
            if (cast == null)
            {
                return NotFound();
            }

            _context.Cast.Remove(cast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CastExists(Guid id)
        {
            return (_context.Cast?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
