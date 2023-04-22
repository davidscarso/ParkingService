using System.ComponentModel.DataAnnotations;

namespace ParkingService.Models
{
    public class Stay
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CheckInTime { get; set; }

        [Required]
        public DateTime CheckOutTime { get; set; }

        [Required]
        public Guid VehicleId { get; set; }

        public Stay(DateTime checkInTime, DateTime checkOutTime, Guid vehicleId)
        {
            Id = Guid.NewGuid();

            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
            VehicleId = vehicleId;
        }
    }
}
