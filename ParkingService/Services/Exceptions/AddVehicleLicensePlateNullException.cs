using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class AddVehicleLicensePlateNullException : Exception
    {
        public AddVehicleLicensePlateNullException()
        {
        }

        public AddVehicleLicensePlateNullException(string message) : base(message)
        {
        }

        public AddVehicleLicensePlateNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddVehicleLicensePlateNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
