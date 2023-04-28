using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckInLicensePlateAlreadyExistsException : Exception
    {
        public CheckInLicensePlateAlreadyExistsException()
        {
        }

        public CheckInLicensePlateAlreadyExistsException(string message) : base(message)
        {
        }

        public CheckInLicensePlateAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckInLicensePlateAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
