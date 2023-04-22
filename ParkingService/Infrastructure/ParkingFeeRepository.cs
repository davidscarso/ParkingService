using ParkingService.Models;
using ParkingService.Infrastructure.Interfaces;

namespace ParkingService.Infrastructure
{
    public class ParkingFeeRepository : IParkingFeeRepository
    {
        private readonly APIDbContext _context;

        public ParkingFeeRepository(APIDbContext context)
        {
            _context = context;
        }

        public Task<ParkingFee> Add(ParkingFee item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkingFee> AsEnumerable()
        {
            throw new NotImplementedException();
        }
    }
}
