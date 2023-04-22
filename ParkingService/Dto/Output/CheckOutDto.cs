namespace ParkingService.Dto.Output
{
    public class CheckOutDto
    {
        public string LicensePlate { get; set; }

        public DateTime CheckInTime { get; set; }

        public DateTime CheckOutTime { get; set; }

        public int TotalTime { get; set; }

        public decimal Amount { get; set; }

    }
}
