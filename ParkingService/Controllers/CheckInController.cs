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
    }
}
