using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckOutLicensePlateEmptyException : Exception
    {
        public CheckOutLicensePlateEmptyException()
        {
        }

        public CheckOutLicensePlateEmptyException(string message) : base(message)
        {
        }

        public CheckOutLicensePlateEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckOutLicensePlateEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
