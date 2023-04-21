namespace ParkingService.Domain
{
    public class OficialVehicle : Vehicle
    {
        public OficialVehicle(string licensePlate) : base(licensePlate)
        {
        }

        public override VehicleType GetVehicleType()
        {
            return VehicleType.OFICIAL;
        }

        public override void ProcessCheckOut()
        {
            throw new NotImplementedException();
        }
    }
}
