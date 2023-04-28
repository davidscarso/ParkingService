using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckOutLicensePlateNullException : Exception
    {
        public CheckOutLicensePlateNullException()
        {
        }

        public CheckOutLicensePlateNullException(string message) : base(message)
        {
        }

        public CheckOutLicensePlateNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckOutLicensePlateNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
