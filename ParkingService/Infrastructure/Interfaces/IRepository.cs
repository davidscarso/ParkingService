using ParkingService.Models;

namespace ParkingService.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> AsEnumerable();

        Task<T> Add(T item);
    }
}