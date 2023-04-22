using Microsoft.EntityFrameworkCore;
using ParkingService.Infrastructure.Interfaces;
using ParkingService.Models;

namespace ParkingService.Infrastructure
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly APIDbContext _context;

        public VehicleRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> Add(Vehicle vehicle)
        {

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return await _context.Vehicles.FindAsync(vehicle.Id);
        }

        public IEnumerable<Vehicle> AsEnumerable()
        {
            //return _context.Vehicles;

            return _context.Vehicles.ToList();
        }

        public async Task<Vehicle> Update(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return await _context.Vehicles.FindAsync(vehicle.Id);

        }
    }
}
