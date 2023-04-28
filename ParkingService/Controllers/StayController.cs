using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
