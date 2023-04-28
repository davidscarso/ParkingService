using System;
using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class AddVehicleLicensePlateInvalidException : Exception
    {
        public AddVehicleLicensePlateInvalidException()
        {
        }

        public AddVehicleLicensePlateInvalidException(string message) : base(message)
        {
        }

        public AddVehicleLicensePlateInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddVehicleLicensePlateInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
