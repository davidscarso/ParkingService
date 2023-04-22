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

        public async Task<ParkingFee> Add(ParkingFee parkingFee)
        {
            _context.ParkingFees.Add(parkingFee);
            await _context.SaveChangesAsync();

            return await _context.ParkingFees.FindAsync(parkingFee.Id);
        }

        public IEnumerable<ParkingFee> AsEnumerable()
        {
            return _context.ParkingFees;
        }
    }
}
