using ParkingService.Models;
using ParkingService.Infrastructure.Interfaces;

namespace ParkingService.Infrastructure
{
    public class StayRepository : IStayRepository
    {
        private readonly APIDbContext _context;

        public StayRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<Stay> Add(Stay stay)
        {
            _context.Stays.Add(stay);
            await _context.SaveChangesAsync();

            return await _context.Stays.FindAsync(stay.Id);
        }

        public IEnumerable<Stay> AsEnumerable()
        {
            return _context.Stays;
        }

        public void DeleteAll()
        {
            _context.Stays.RemoveRange(_context.Stays.ToList());

            _context.SaveChangesAsync();
        }
    }
}
