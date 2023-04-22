using ParkingService.Models;

namespace ParkingService.Infrastructure.Interfaces
{
    public interface ICheckInRepository : IRepository<CheckIn>
    {
        public Task DeleteAsync(Guid id);
    }
}
