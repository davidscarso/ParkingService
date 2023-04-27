using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingService.Models;

namespace ParkingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficialVehicleController : ControllerBase
    {
        private readonly APIDbContext _context;

        public OficialVehicleController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/OficialVehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OficialVehicle>>> GetOficialVehicle()
        {
            if (_context.OficialVehicles == null)
            {
                return NotFound();
            }
            return await _context.OficialVehicles.Where(x => x.VehicleType == VehicleType.OFICIAL).ToListAsync();
        }

        // GET: api/OficialVehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OficialVehicle>> GetOficialVehicle(Guid id)
        {
            if (_context.OficialVehicles == null)
            {
                return NotFound();
            }
            var oficialVehicle = await _context.OficialVehicles.FindAsync(id);

            if (oficialVehicle == null)
            {
                return NotFound();
            }

            return oficialVehicle;
        }

        // PUT: api/OficialVehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOficialVehicle(Guid id, OficialVehicle oficialVehicle)
        {
            if (id != oficialVehicle.Id)
            {
                return BadRequest();
            }

            _context.Entry(oficialVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OficialVehicleExists(id))
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

        // POST: api/OficialVehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OficialVehicle>> PostOficialVehicle(OficialVehicle oficialVehicle)
        {
            if (_context.OficialVehicles == null)
            {
                return Problem("Entity set 'APIDbContext.OficialVehicle'  is null.");
            }
            _context.OficialVehicles.Add(oficialVehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOficialVehicle", new { id = oficialVehicle.Id }, oficialVehicle);
        }

        // DELETE: api/OficialVehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOficialVehicle(Guid id)
        {
            if (_context.OficialVehicles == null)
            {
                return NotFound();
            }
            var oficialVehicle = await _context.OficialVehicles.FindAsync(id);
            if (oficialVehicle == null)
            {
                return NotFound();
            }

            _context.OficialVehicles.Remove(oficialVehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OficialVehicleExists(Guid id)
        {
            return (_context.OficialVehicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
