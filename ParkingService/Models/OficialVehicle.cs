namespace ParkingService.Models
{
    public class OficialVehicle : Vehicle
    {
        public OficialVehicle(string licensePlate) : base(licensePlate)
        {
            VehicleType = VehicleType.OFICIAL;
        }

        public override void ProcessCheckOut()
        {
            throw new NotImplementedException();
        }
    }
}
