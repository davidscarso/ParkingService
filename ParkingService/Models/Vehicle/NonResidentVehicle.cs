namespace ParkingService.Models
{
    public class NonResidentVehicle : VehicleBase
    {
        public NonResidentVehicle(string licensePlate) : base(licensePlate)
        {
            VehicleType = VehicleType.NON_RESIDENT;
        }
    }
}
