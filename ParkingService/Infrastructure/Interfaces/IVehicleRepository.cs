using ParkingService.Models;

namespace ParkingService.Infrastructure.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<Vehicle> Update(Vehicle vehicle);
    }
}
