using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckInLicensePlateEmptyException : Exception
    {
        public CheckInLicensePlateEmptyException()
        {
        }

        public CheckInLicensePlateEmptyException(string message) : base(message)
        {
        }

        public CheckInLicensePlateEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckInLicensePlateEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
