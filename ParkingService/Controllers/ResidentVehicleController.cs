using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (_context.ResidentVehicles == null)
            {
                return NotFound();
            }
            return await _context.ResidentVehicles.Where(x => x.VehicleType == VehicleType.RESIDENT).ToListAsync();
        }

        // GET: api/ResidentVehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResidentVehicle>> GetResidentVehicle(Guid id)
        {
            if (_context.ResidentVehicles == null)
            {
                return NotFound();
            }
            var residentVehicle = await _context.ResidentVehicles.FindAsync(id);

            if (residentVehicle == null)
            {
                return NotFound();
            }

            return residentVehicle;
        }

    }
}
