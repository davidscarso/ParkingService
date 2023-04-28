using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class AddVehicleLicensePlateEmptyException : Exception
    {
        public AddVehicleLicensePlateEmptyException()
        {
        }

        public AddVehicleLicensePlateEmptyException(string message) : base(message)
        {
        }

        public AddVehicleLicensePlateEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddVehicleLicensePlateEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
