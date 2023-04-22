namespace ParkingService.Models
{
    public class NonResidentVehicle : Vehicle
    {
        public NonResidentVehicle(string licensePlate) : base(licensePlate)
        {
            VehicleType = VehicleType.NON_RESIDENT;
        }
    }
}
