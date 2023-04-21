namespace ParkingService.Models
{
    abstract public class Vehicle
    {
        public string LicensePlate { get; set; }

        protected Vehicle(string licensePlate)
        {
            LicensePlate = licensePlate;
        }

        public abstract void ProcessCheckOut();
        public abstract VehicleType GetVehicleType();
    }

}
