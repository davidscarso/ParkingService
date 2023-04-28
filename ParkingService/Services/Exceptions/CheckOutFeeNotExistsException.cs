using System.Runtime.Serialization;

namespace ParkingService.Services.Exceptions
{
    [Serializable]
    public class CheckOutFeeNotExistsException : Exception
    {
        public CheckOutFeeNotExistsException()
        {
        }

        public CheckOutFeeNotExistsException(string message) : base(message)
        {
        }

        public CheckOutFeeNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckOutFeeNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
