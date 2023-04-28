using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckInLicensePlateNotExistsException : Exception
    {
        public CheckInLicensePlateNotExistsException()
        {
        }

        public CheckInLicensePlateNotExistsException(string message) : base(message)
        {
        }

        public CheckInLicensePlateNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckInLicensePlateNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
