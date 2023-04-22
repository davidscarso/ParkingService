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

        public Task<Stay> Add(Stay item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stay> AsEnumerable()
        {
            throw new NotImplementedException();
        }
    }
}
