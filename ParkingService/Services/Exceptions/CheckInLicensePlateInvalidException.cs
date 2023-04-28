using System;
using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckInLicensePlateInvalidException : Exception
    {
        public CheckInLicensePlateInvalidException()
        {
        }

        public CheckInLicensePlateInvalidException(string message) : base(message)
        {
        }

        public CheckInLicensePlateInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckInLicensePlateInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
