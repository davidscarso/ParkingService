namespace ParkingService.Dto.Output
{
    public class OficialVehicleDto
    {
        public Guid Id { get; set; }

        public string LicensePlate { get; set; }

        public OficialVehicleDto(Guid id, string licensePlate)
        {
            Id = id;
            LicensePlate = licensePlate;
        }
    }
}
