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
    
    }
}
