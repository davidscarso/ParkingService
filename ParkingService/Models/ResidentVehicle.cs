namespace ParkingService.Models
{
    public class ResidentVehicle : Vehicle
    {
        public int TotalTime { get; set; }

        public ResidentVehicle(string licensePlate) : base(licensePlate)
        {
            TotalTime = 0;
        }

        public override void ProcessCheckOut()
        {
            throw new NotImplementedException();
        }

        public override VehicleType GetVehicleType()
        {
            return VehicleType.RESIDENT;
        }
    }
}
