using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckOutLicensePlateInvalidException : Exception
    {
        public CheckOutLicensePlateInvalidException()
        {
        }

        public CheckOutLicensePlateInvalidException(string message) : base(message)
        {
        }

        public CheckOutLicensePlateInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckOutLicensePlateInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
