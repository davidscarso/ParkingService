using ParkingService.Models;
using ParkingService.Infrastructure.Interfaces;

namespace ParkingService.Infrastructure
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly APIDbContext _context;

        public VehicleRepository(APIDbContext context)
        {
            _context = context;
        }

        public Task<Vehicle> Add(Vehicle item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> AsEnumerable()
        {
            throw new NotImplementedException();
        }
    }
}
