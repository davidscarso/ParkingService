using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckInLicensePlateNullException : Exception
    {
        public CheckInLicensePlateNullException()
        {
        }

        public CheckInLicensePlateNullException(string message) : base(message)
        {
        }

        public CheckInLicensePlateNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckInLicensePlateNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
