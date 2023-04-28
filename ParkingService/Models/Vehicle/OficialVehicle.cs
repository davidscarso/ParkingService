namespace ParkingService.Models
{
    public class OficialVehicle : VehicleBase
    {
        public OficialVehicle(string licensePlate) : base(licensePlate)
        {
            VehicleType = VehicleType.OFICIAL;
        }
              
    }
}
