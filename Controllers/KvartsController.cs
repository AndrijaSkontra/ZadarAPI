using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZadarAPI.Dto.Kvart;
using ZadarAPI.Models;

namespace ZadarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KvartsController : ControllerBase
    {
        private readonly ZadarContext _context;

        public KvartsController(ZadarContext context)
        {
            _context = context;
        }

        // GET: api/Kvarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kvart>>> GetKvarts()
        {
            return await _context.Kvarts.ToListAsync();
        }

        // GET: api/Kvarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kvart>> GetKvart(int id)
        {
            var kvart = await _context.Kvarts.FindAsync(id);

            if (kvart == null)
            {
                return NotFound();
            }

            return kvart;
        }

        // PUT: api/Kvarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKvart(int id, Kvart kvart)
        {
            if (id != kvart.Id)
            {
                return BadRequest();
            }

            _context.Entry(kvart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KvartExists(id))
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

        // POST: api/Kvarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kvart>> PostKvart(CreateKvartDto createKvartDto)
        {
            Kvart kvart = new Kvart()
            {
                LifeQuality = createKvartDto.LifeQuality,
                Name = createKvartDto.Name,
            };
            _context.Kvarts.Add(kvart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKvart", new { id = kvart.Id }, kvart);
        }

        // DELETE: api/Kvarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKvart(int id)
        {
            var kvart = await _context.Kvarts.FindAsync(id);
            if (kvart == null)
            {
                return NotFound();
            }

            _context.Kvarts.Remove(kvart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KvartExists(int id)
        {
            return _context.Kvarts.Any(e => e.Id == id);
        }
    }
}
