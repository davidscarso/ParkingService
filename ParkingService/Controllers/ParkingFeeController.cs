using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingService.Models;

namespace ParkingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingFeeController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ParkingFeeController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/ParkingFee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingFee>>> GetParkingFees()
        {
            if (_context.ParkingFees == null)
            {
                return NotFound();
            }
            return await _context.ParkingFees.ToListAsync();
        }

        // GET: api/ParkingFee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingFee>> GetParkingFee(Guid id)
        {
            if (_context.ParkingFees == null)
            {
                return NotFound();
            }
            var parkingFee = await _context.ParkingFees.FindAsync(id);

            if (parkingFee == null)
            {
                return NotFound();
            }

            return parkingFee;
        }

        // PUT: api/ParkingFee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingFee(Guid id, ParkingFee parkingFee)
        {
            if (id != parkingFee.Id)
            {
                return BadRequest();
            }

            _context.Entry(parkingFee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingFeeExists(id))
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

        // POST: api/ParkingFee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParkingFee>> PostParkingFee(ParkingFee parkingFee)
        {
            if (_context.ParkingFees == null)
            {
                return Problem("Entity set 'APIDbContext.ParkingFees'  is null.");
            }
            _context.ParkingFees.Add(parkingFee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingFee", new { id = parkingFee.Id }, parkingFee);
        }

        // DELETE: api/ParkingFee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParkingFee(Guid id)
        {
            if (_context.ParkingFees == null)
            {
                return NotFound();
            }
            var parkingFee = await _context.ParkingFees.FindAsync(id);
            if (parkingFee == null)
            {
                return NotFound();
            }

            _context.ParkingFees.Remove(parkingFee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingFeeExists(Guid id)
        {
            return (_context.ParkingFees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
