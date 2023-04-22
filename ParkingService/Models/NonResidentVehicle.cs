namespace ParkingService.Models
{
    public class VehiculoNoResidente : Vehicle
    {
        public VehiculoNoResidente(string licensePlate) : base(licensePlate)
        {
            VehicleType = VehicleType.NON_RESIDENT;
        }

        public override void ProcessCheckOut()
        {
            throw new NotImplementedException();
        }
    }
}
