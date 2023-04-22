using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingService.Models;

namespace ParkingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly APIDbContext _context;

        public CheckInController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/CheckIn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckIn>>> GetCheckIns()
        {
            if (_context.CheckIns == null)
            {
                return NotFound();
            }
            return await _context.CheckIns.ToListAsync();
        }

        // GET: api/CheckIn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckIn>> GetCheckIn(Guid id)
        {
            if (_context.CheckIns == null)
            {
                return NotFound();
            }
            var checkIn = await _context.CheckIns.FindAsync(id);

            if (checkIn == null)
            {
                return NotFound();
            }

            return checkIn;
        }

        // PUT: api/CheckIn/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckIn(Guid id, CheckIn checkIn)
        {
            if (id != checkIn.Id)
            {
                return BadRequest();
            }

            _context.Entry(checkIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckInExists(id))
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

        // POST: api/CheckIn
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CheckIn>> PostCheckIn(CheckIn checkIn)
        {
            if (_context.CheckIns == null)
            {
                return Problem("Entity set 'APIDbContext.CheckIns'  is null.");
            }
            _context.CheckIns.Add(checkIn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckIn", new { id = checkIn.Id }, checkIn);
        }

        // DELETE: api/CheckIn/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckIn(Guid id)
        {
            if (_context.CheckIns == null)
            {
                return NotFound();
            }
            var checkIn = await _context.CheckIns.FindAsync(id);
            if (checkIn == null)
            {
                return NotFound();
            }

            _context.CheckIns.Remove(checkIn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckInExists(Guid id)
        {
            return (_context.CheckIns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
