using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingService;
using ParkingService.Models;

namespace ParkingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StayController : ControllerBase
    {
        private readonly APIDbContext _context;

        public StayController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Stay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stay>>> GetStays()
        {
          if (_context.Stays == null)
          {
              return NotFound();
          }
            return await _context.Stays.ToListAsync();
        }

        // GET: api/Stay/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stay>> GetStay(Guid id)
        {
          if (_context.Stays == null)
          {
              return NotFound();
          }
            var stay = await _context.Stays.FindAsync(id);

            if (stay == null)
            {
                return NotFound();
            }

            return stay;
        }

        // PUT: api/Stay/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStay(Guid id, Stay stay)
        {
            if (id != stay.Id)
            {
                return BadRequest();
            }

            _context.Entry(stay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StayExists(id))
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

        // POST: api/Stay
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stay>> PostStay(Stay stay)
        {
          if (_context.Stays == null)
          {
              return Problem("Entity set 'APIDbContext.Stays'  is null.");
          }
            _context.Stays.Add(stay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStay", new { id = stay.Id }, stay);
        }

        // DELETE: api/Stay/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStay(Guid id)
        {
            if (_context.Stays == null)
            {
                return NotFound();
            }
            var stay = await _context.Stays.FindAsync(id);
            if (stay == null)
            {
                return NotFound();
            }

            _context.Stays.Remove(stay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StayExists(Guid id)
        {
            return (_context.Stays?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
