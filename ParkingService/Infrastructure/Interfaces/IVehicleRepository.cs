using ParkingService.Models;

namespace ParkingService.Infrastructure.Interfaces
{
    public interface IVehicleRepository : IRepository<VehicleBase>
    {
        Task<VehicleBase> Update(VehicleBase vehicle);
    }
}
