using Microsoft.EntityFrameworkCore;
using ParkingService.Infrastructure.Interfaces;
using ParkingService.Models;
using System.Threading.Tasks;

namespace ParkingService.Infrastructure
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly APIDbContext _context;

        public CheckInRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<CheckIn> Add(CheckIn checkIn)
        {
            _context.CheckIns.Add(checkIn);
            await _context.SaveChangesAsync();

            return await _context.CheckIns.FindAsync(checkIn.Id);
        }

        public IEnumerable<CheckIn> AsEnumerable()
        {
            return _context.CheckIns;
        }
    }
}
