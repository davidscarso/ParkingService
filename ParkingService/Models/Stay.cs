namespace ParkingService.Models
{
    public class Stay
    {
        public TimeSpan CheckInTime { get; }
        public TimeSpan CheckOutTime { get; }
        public OficialVehicle Vehicle { get; }

        public Stay(TimeSpan checkInTime, OficialVehicle vehicle)
        {
            CheckInTime = checkInTime;
            CheckOutTime = DateTime.Today.TimeOfDay;
            Vehicle = vehicle;
        }
    }
}
