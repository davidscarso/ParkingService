using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckOutCheckInNotFoundException : Exception
    {
        public CheckOutCheckInNotFoundException()
        {
        }

        public CheckOutCheckInNotFoundException(string message) : base(message)
        {
        }

        public CheckOutCheckInNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckOutCheckInNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
