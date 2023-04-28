using System;
using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class AddVehicleLicensePlateAlreadyExistsException : Exception
    {
        public AddVehicleLicensePlateAlreadyExistsException()
        {
        }

        public AddVehicleLicensePlateAlreadyExistsException(string message) : base(message)
        {
        }

        public AddVehicleLicensePlateAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddVehicleLicensePlateAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
