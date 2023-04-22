using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingService.Dto.Output
{
    public class CheckInDto
    {
        public Guid Id { get; set; }

        public string LicensePlate { get; set; }

        public DateTime CheckInTime { get; set; }

        public CheckInDto(Guid id, string licensePlate, DateTime checkInTime)
        {
            Id = id;
            LicensePlate = licensePlate;
            CheckInTime = checkInTime;
        }
    }
}
