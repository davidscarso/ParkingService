namespace ParkingService.Dto.Output
{
    public class ResidentVehicleDto
    {
        public Guid Id { get; set; }

        public string LicensePlate { get; set; }

        public int TotalTime { get; set; }

        public ResidentVehicleDto(Guid id, string licensePlate, int totalTime)
        {
            Id = id;
            LicensePlate = licensePlate;
            TotalTime = totalTime;
        }
    }
}
