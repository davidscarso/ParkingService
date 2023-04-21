namespace ParkingService.Models
{
    public class VehiculoNoResidente : Vehicle
    {
        public VehiculoNoResidente(string licensePlate) : base(licensePlate)
        {
        }

        public override VehicleType GetVehicleType()
        {
            return VehicleType.NON_RESIDENT;
        }

        public override void ProcessCheckOut()
        {
            throw new NotImplementedException();
        }
    }
}
