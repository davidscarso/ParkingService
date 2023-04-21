namespace ParkingService.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> AsEnumerable();

        void Add(T item);
    }
}