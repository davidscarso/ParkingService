namespace ParkingService.Domain
{
    public class CheckIn
    {
        public string LicensePlate { get; set; }

        public TimeSpan CheckInTime { get; set; }

        public CheckIn(string licensePlate)
        {
            LicensePlate = licensePlate;
            CheckInTime = DateTime.Now.TimeOfDay;
        }
    }
}
