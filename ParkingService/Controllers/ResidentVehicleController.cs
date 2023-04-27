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
    public class ResidentVehicleController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ResidentVehicleController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/ResidentVehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResidentVehicle>>> GetResidentVehicle()
        {
            if (_context.ResidentVehicle == null)
            {
                return NotFound();
            }
            return await _context.ResidentVehicle.Where(x => x.VehicleType == VehicleType.RESIDENT).ToListAsync();
        }

        // GET: api/ResidentVehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResidentVehicle>> GetResidentVehicle(Guid id)
        {
            if (_context.ResidentVehicle == null)
            {
                return NotFound();
            }
            var residentVehicle = await _context.ResidentVehicle.FindAsync(id);

            if (residentVehicle == null)
            {
                return NotFound();
            }

            return residentVehicle;
        }

        // PUT: api/ResidentVehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResidentVehicle(Guid id, ResidentVehicle residentVehicle)
        {
            if (id != residentVehicle.Id)
            {
                return BadRequest();
            }

            _context.Entry(residentVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentVehicleExists(id))
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

        // POST: api/ResidentVehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResidentVehicle>> PostResidentVehicle(ResidentVehicle residentVehicle)
        {
            if (_context.ResidentVehicle == null)
            {
                return Problem("Entity set 'APIDbContext.ResidentVehicle'  is null.");
            }
            _context.ResidentVehicle.Add(residentVehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResidentVehicle", new { id = residentVehicle.Id }, residentVehicle);
        }

        // DELETE: api/ResidentVehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidentVehicle(Guid id)
        {
            if (_context.ResidentVehicle == null)
            {
                return NotFound();
            }
            var residentVehicle = await _context.ResidentVehicle.FindAsync(id);
            if (residentVehicle == null)
            {
                return NotFound();
            }

            _context.ResidentVehicle.Remove(residentVehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResidentVehicleExists(Guid id)
        {
            return (_context.ResidentVehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
